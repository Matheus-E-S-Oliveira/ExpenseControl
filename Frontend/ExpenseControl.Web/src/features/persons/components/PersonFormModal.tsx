/**
 * PersonFormModal - Modal para criação e edição de pessoas
 *
 * Props:
 * - onClose: função chamada ao fechar o modal
 * - onSuccess: função chamada após salvar com sucesso
 * - person: objeto opcional com dados da pessoa (para edição)
 *
 * Lógica:
 * - Mantém estados locais para `name`, `age`, `errors`, `loading`, `message` e `success`
 * - `handleSubmit` envia dados para API:
 *   - Criação via createPerson se `person` não existir
 *   - Edição via updatePerson se `person` existir
 *   - Valida campos antes de enviar
 * - `validateForm` verifica:
 *   - Nome obrigatório e <= 200 caracteres
 *   - Idade obrigatória, > 0 e <= 120
 * - Mostra erros abaixo dos inputs
 * - Mostra ModalGlobal para mensagens de sucesso ou erro
 * - Inputs com estilização inline e feedback visual de erro
 */
import { useState } from "react";
import { createPerson, updatePerson } from "../services/personService";
import ModalGlobal from "../../../components/ModalGlobal";

type Props = {
  onClose: () => void;
  onSuccess: () => void;
  person?: { id: string; name: string; age: number };
};

export default function PersonFormModal({ onClose, onSuccess, person }: Props) {
  const [name, setName] = useState(person?.name || "");
  const [age, setAge] = useState(person?.age.toString() || "");
  const [message, setMessage] = useState("");
  const [showMessage, setShowMessage] = useState(false);
  const [success, setSuccess] = useState(true);
  const [loading, setLoading] = useState(false);
  const [errors, setErrors] = useState<any>({});

  /** Envia dados para API após validação */
  const handleSubmit = async () => {
    setLoading(true);

    const isValid = validateForm();

    if (!isValid) {
      setLoading(false);
      return;
    }

    try {
      let responseMessage = "";

      if (person) {
        const response = await updatePerson(person.id, {
          name,
          age: Number(age),
        });
        responseMessage = response.message || "Pessoa atualizada com sucesso!";
      } else {
        const response = await createPerson({
          name,
          age: Number(age),
        });
        responseMessage = response.message || "Pessoa cadastrada com sucesso!";
      }

      setMessage(responseMessage);
      setSuccess(true);
      setShowMessage(true);
    } catch (error: any) {
      setMessage(error?.response?.data?.message || "Erro ao salvar!");
      setSuccess(false);
      setShowMessage(true);
    } finally {
      setLoading(false);
    }
  };

  /** Valida os campos do formulário */
  const validateForm = () => {
    const newErrors: any = {};

    if (!name.trim()) {
      newErrors.name = "Nome é obrigatório";
    } else if (name.length > 200) {
      newErrors.name = "Máximo de 200 caracteres";
    }

    if (!age) {
      newErrors.age = "Idade é obrigatória";
    } else if (Number(age) <= 0) {
      newErrors.age = "Idade deve ser maior que zero";
    } else if (Number(age) > 120) {
      newErrors.age = "Idade máxima permitida é 120";
    }

    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };

  return (
    <>
      <div
        style={{
          position: "fixed",
          top: 0,
          left: 0,
          right: 0,
          bottom: 0,
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
          <h2>{person ? "Editar Pessoa" : "Cadastrar Pessoa"}</h2>
          <div style={{ display: "flex", flexDirection: "column" }}>
            <span style={{ fontSize: "11px", color: "#999" }}>
              {name.length}/400
            </span>
            <input
              type="text"
              placeholder="Nome"
              maxLength={200}
              value={name}
              onChange={(e) => {
                setName(e.target.value);
                setErrors((prev: any) => ({ ...prev, name: "" }));
              }}
              style={{
                width: "94%",
                padding: "8px",
                marginBottom: "5px",
                border: errors.name ? "1px solid red" : "1px solid #ccc",
              }}
            />

            {errors.name && (
              <span
                style={{ color: "red", fontSize: "12px", marginBottom: "10px" }}
              >
                {errors.name}
              </span>
            )}
            <input
              type="number"
              min={0}
              max={120}
              placeholder="Idade"
              value={age}
              onChange={(e) => {
                setAge(e.target.value);
                setErrors((prev: any) => ({ ...prev, age: "" }));
              }}
              style={{
                width: "94%",
                padding: "8px",
                marginBottom: "5px",
                border: errors.age ? "1px solid red" : "1px solid #ccc",
              }}
            />

            {errors.age && (
              <span
                style={{ color: "red", fontSize: "12px", marginBottom: "10px" }}
              >
                {errors.age}
              </span>
            )}
          </div>
          <div
            style={{ display: "flex", justifyContent: "flex-end", gap: "10px" }}
          >
            <button
              onClick={onClose}
              style={{
                backgroundColor: "#aaa",
                color: "#fff",
                border: "none",
                padding: "10px",
                borderRadius: "5px",
                cursor: "pointer",
              }}
              disabled={loading}
            >
              Cancelar
            </button>
            <button
              onClick={handleSubmit}
              style={{
                backgroundColor: "#0080FF",
                color: "#fff",
                border: "none",
                padding: "10px",
                borderRadius: "5px",
                cursor: "pointer",
              }}
              disabled={loading}
            >
              {loading ? "Salvando..." : "Salvar"}
            </button>
          </div>
        </div>
      </div>

      {/* Modal global para mensagens de sucesso/erro */}
      {showMessage && (
        <ModalGlobal
          message={message}
          success={success}
          onClose={() => {
            setShowMessage(false);
            onSuccess();
            onClose();
          }}
        />
      )}
    </>
  );
}
