import { useEffect, useState } from "react";
import { getPersons } from "../../persons/services/personService";
import { getCategories } from "../../categories/services/categoryService";
import { createTransaction } from "../services/transactionService";
import ModalGlobal from "../../../components/ModalGlobal";

/**
 * TransactionFormModal
 *
 * Modal para criação de novas transações financeiras.
 *
 * Funcionalidades:
 * - Cadastro de transações com campos: descrição, valor, tipo, pessoa e categoria
 * - Validação completa do formulário (campos obrigatórios, limites de valores e caracteres)
 * - Regras de negócio (ex: menores de idade só podem ter despesas)
 * - Filtro dinâmico de categorias conforme o tipo selecionado (Despesa/Receita)
 * - Feedback visual de erros
 * - Mensagens globais de sucesso ou erro via ModalGlobal
 * - Atualiza lista de transações após cadastro com onSuccess()
 *
 * Props:
 * @param onClose Função para fechar o modal
 * @param onSuccess Função chamada após cadastro bem-sucedido
 */
export default function TransactionFormModal({ onClose, onSuccess }: any) {
  // Estados do formulário
  const [description, setDescription] = useState(""); // descrição da transação
  const [value, setValue] = useState(""); // valor em centavos (string)
  const [displayValue, setDisplayValue] = useState(""); // valor formatado (R$ 0,00)
  const [type, setType] = useState(1); // 1 = despesa, 2 = receita
  const [personId, setPersonId] = useState(""); // pessoa associada
  const [categoryId, setCategoryId] = useState(""); // categoria associada

  // Dados externos
  const [persons, setPersons] = useState<any[]>([]); // lista de pessoas
  const [categories, setCategories] = useState<any[]>([]); // lista de categorias

  // Feedback visual
  const [message, setMessage] = useState(""); // mensagem do modal global
  const [showMessage, setShowMessage] = useState(false); // controla exibição do modal
  const [success, setSuccess] = useState(true); // sucesso ou erro
  const [loading, setLoading] = useState(false); // indicador de carregamento

  // Estado de erros do formulário
  const [errors, setErrors] = useState<any>({});

  // Carrega pessoas e categorias ao montar o componente
  useEffect(() => {
    getPersons().then((r) => setPersons(r.data));
    getCategories().then((r) => setCategories(r.data));
  }, []);

  // Filtra categorias conforme o tipo selecionado
  const filteredCategories = categories.filter((c) => {
    if (c.purpose === 3) return true; // categoria serve para ambos
    if (type === 1) return c.purpose === 1; // despesa
    if (type === 2) return c.purpose === 2; // receita
    return false;
  });

  // Formata valor numérico em BRL
  const formatCurrency = (val: string) => {
    const number = Number(val.replace(/\D/g, "")) / 100;
    return number.toLocaleString("pt-BR", {
      style: "currency",
      currency: "BRL",
    });
  };

  // Valida formulário, retorna true se válido
  const validateForm = () => {
    const newErrors: any = {};

    if (!description.trim()) newErrors.description = "Descrição é obrigatória";
    else if (description.length > 400)
      newErrors.description = "Máximo de 400 caracteres";

    if (!value || Number(value) <= 0)
      newErrors.value = "Valor deve ser maior que zero";
    else if (Number(value) > 1000000)
      newErrors.value = "Valor máximo permitido é R$ 1.000.000";

    if (!personId) newErrors.personId = "Selecione uma pessoa";
    if (!categoryId) newErrors.categoryId = "Selecione uma categoria";

    const selectedPerson = persons.find((p) => p.id === personId);
    if (selectedPerson?.age < 18 && type === 2)
      newErrors.type = "Menores de idade só podem ter despesas";

    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };

  // Submete formulário
  const handleSubmit = async () => {
    setLoading(true);

    const isValid = validateForm();
    if (!isValid) {
      setLoading(false);
      return;
    }

    try {
      const response = await createTransaction({
        description,
        value: Number(value) / 100,
        type,
        personId,
        categoryId,
      });

      onSuccess(); // atualiza lista de transações
      onClose(); // fecha modal

      setTimeout(() => {
        setMessage(response.message || "Transação criada com sucesso!");
        setSuccess(true);
        setShowMessage(true);
      }, 100);
    } catch (err: any) {
      setMessage(err?.response?.data?.message || "Erro ao criar transação!");
      setSuccess(false);
      setShowMessage(true);
    } finally {
      setLoading(false);
    }
  };

  // JSX do modal e formulário permanece intacto
  return (
    <>
      <div
        style={{
          position: "fixed",
          inset: 0,
          backgroundColor: "rgba(0,0,0,0.4)",
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
          zIndex: 999,
        }}
      >
        <div
          style={{
            backgroundColor: "#fff",
            padding: "20px",
            borderRadius: "10px",
            minWidth: "400px",
          }}
        >
          <h2>Nova Transação</h2>

          <div style={{ display: "flex", flexDirection: "column" }}>
            {/* Descrição */}
            <span style={{ fontSize: "11px", color: "#999" }}>
              {description.length}/400
            </span>
            <input
              type="text"
              maxLength={400}
              placeholder="Descrição"
              value={description}
              onChange={(e) => {
                setDescription(e.target.value);
                setErrors((prev: any) => ({ ...prev, description: "" }));
              }}
              style={{
                padding: "8px",
                marginBottom: "5px",
                border: errors.description ? "1px solid red" : "1px solid #ccc",
              }}
            />
            {errors.description && (
              <span
                style={{ color: "red", fontSize: "12px", marginBottom: "10px" }}
              >
                {errors.description}
              </span>
            )}

            {/* Valor */}
            <input
              type="text"
              placeholder="R$ 0,00"
              value={displayValue}
              onChange={(e) => {
                const raw = e.target.value.replace(/\D/g, "");
                if (!raw) {
                  setValue("");
                  setDisplayValue("");
                  return;
                }
                if (Number(raw) > 100000000) return;
                setValue(raw);
                setDisplayValue(formatCurrency(raw));
                setErrors((prev: any) => ({ ...prev, value: "" }));
              }}
              style={{
                padding: "8px",
                marginBottom: "5px",
                border: errors.value ? "1px solid red" : "1px solid #ccc",
              }}
            />
            {errors.value && (
              <span
                style={{ color: "red", fontSize: "12px", marginBottom: "10px" }}
              >
                {errors.value}
              </span>
            )}

            {/* Tipo */}
            <select
              value={type}
              onChange={(e) => {
                const newType = Number(e.target.value);
                setType(newType);
                setCategoryId("");
                setErrors((prev: any) => ({ ...prev, type: "" }));
              }}
              style={{
                padding: "8px",
                marginBottom: "5px",
                border: errors.type ? "1px solid red" : "1px solid #ccc",
              }}
            >
              <option value={1}>Despesa</option>
              <option value={2}>Receita</option>
            </select>
            {errors.type && (
              <span
                style={{ color: "red", fontSize: "12px", marginBottom: "10px" }}
              >
                {errors.type}
              </span>
            )}

            {/* Pessoa */}
            <select
              value={personId}
              onChange={(e) => {
                setPersonId(e.target.value);
                setErrors((prev: any) => ({ ...prev, personId: "" }));
              }}
              style={{
                padding: "8px",
                marginBottom: "5px",
                border: errors.personId ? "1px solid red" : "1px solid #ccc",
              }}
            >
              <option value="">Selecione a Pessoa</option>
              {persons.map((p) => (
                <option key={p.id} value={p.id}>
                  {p.name}
                </option>
              ))}
            </select>
            {errors.personId && (
              <span
                style={{ color: "red", fontSize: "12px", marginBottom: "10px" }}
              >
                {errors.personId}
              </span>
            )}

            {/* Categoria */}
            <select
              value={categoryId}
              onChange={(e) => {
                setCategoryId(e.target.value);
                setErrors((prev: any) => ({ ...prev, categoryId: "" }));
              }}
              disabled={filteredCategories.length === 0}
              style={{
                padding: "8px",
                marginBottom: "5px",
                border: errors.categoryId ? "1px solid red" : "1px solid #ccc",
                backgroundColor:
                  filteredCategories.length === 0 ? "#f5f5f5" : "#fff",
                cursor:
                  filteredCategories.length === 0 ? "not-allowed" : "pointer",
              }}
            >
              <option value="">Selecione a Categoria</option>
              {filteredCategories.map((c) => (
                <option key={c.id} value={c.id}>
                  {c.description}
                </option>
              ))}
            </select>
            {errors.categoryId && (
              <span
                style={{ color: "red", fontSize: "12px", marginBottom: "10px" }}
              >
                {errors.categoryId}
              </span>
            )}

            {filteredCategories.length === 0 && (
              <span
                style={{
                  color: "#999",
                  fontSize: "12px",
                  marginBottom: "10px",
                }}
              >
                Não há nenhuma categoria disponível para esse tipo de transação
              </span>
            )}
          </div>

          {/* Botões */}
          <div
            style={{ display: "flex", justifyContent: "flex-end", gap: "10px" }}
          >
            <button
              onClick={onClose}
              disabled={loading}
              style={{
                backgroundColor: "#aaa",
                color: "#fff",
                border: "none",
                padding: "10px",
                borderRadius: "5px",
                cursor: "pointer",
              }}
            >
              Cancelar
            </button>

            <button
              onClick={handleSubmit}
              disabled={loading}
              style={{
                backgroundColor: "#0080FF",
                color: "#fff",
                border: "none",
                padding: "10px",
                borderRadius: "5px",
                cursor: "pointer",
              }}
            >
              {loading ? "Salvando..." : "Salvar"}
            </button>
          </div>
        </div>
      </div>

      {/* ModalGlobal para mensagens de sucesso/erro */}
      {showMessage && (
        <ModalGlobal
          message={message}
          success={success}
          onClose={() => setShowMessage(false)}
        />
      )}
    </>
  );
}
