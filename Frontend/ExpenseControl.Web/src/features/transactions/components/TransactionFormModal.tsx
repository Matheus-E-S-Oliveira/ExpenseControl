import { useEffect, useState } from "react";
import { getPersons } from "../../persons/services/personService";
import { getCategories } from "../../categories/services/categoryService";
import { createTransaction } from "../services/transactionService";
import ModalGlobal from "../../../components/ModalGlobal";

export default function TransactionFormModal({ onClose, onSuccess }: any) {
    const [description, setDescription] = useState("");
    const [value, setValue] = useState("");
    const [displayValue, setDisplayValue] = useState("");
    const [type, setType] = useState(1);
    const [personId, setPersonId] = useState("");
    const [categoryId, setCategoryId] = useState("");

    const [persons, setPersons] = useState<any[]>([]);
    const [categories, setCategories] = useState<any[]>([]);

    const [message, setMessage] = useState("");
    const [showMessage, setShowMessage] = useState(false);
    const [success, setSuccess] = useState(true);
    const [loading, setLoading] = useState(false);

    const [errors, setErrors] = useState<any>({});

    useEffect(() => {
        getPersons().then(r => setPersons(r.data));
        getCategories().then(r => setCategories(r.data));
    }, []);

    const filteredCategories = categories.filter((c) => {
        if (c.purpose === 3) return true; // ambas
        if (type === 1) return c.purpose === 1; // despesa
        if (type === 2) return c.purpose === 2; // receita
        return false;
    });

    const formatCurrency = (val: string) => {
        const number = Number(val.replace(/\D/g, "")) / 100;

        return number.toLocaleString("pt-BR", {
            style: "currency",
            currency: "BRL"
        });
    };

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

            onSuccess();
            onClose();

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

    const validateForm = () => {
        const newErrors: any = {};

        if (!description.trim()) {
            newErrors.description = "Descrição é obrigatória";
        } else if (description.length > 400) {
            newErrors.description = "Máximo de 400 caracteres";
        }

        if (!value || Number(value) <= 0) {
            newErrors.value = "Valor deve ser maior que zero";
        } else if (Number(value) > 1000000) {
            newErrors.value = "Valor máximo permitido é R$ 1.000.000";
        }

        if (!personId) {
            newErrors.personId = "Selecione uma pessoa";
        }

        if (!categoryId) {
            newErrors.categoryId = "Selecione uma categoria";
        }

        const selectedPerson = persons.find(p => p.id === personId);

        if (selectedPerson?.age < 18 && type === 2) {
            newErrors.type = "Menores de idade só podem ter despesas";
        }

        setErrors(newErrors);
        return Object.keys(newErrors).length === 0;
    };

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
                                border: errors.description ? "1px solid red" : "1px solid #ccc"
                            }}
                        />
                        {errors.description && (
                            <span style={{ color: "red", fontSize: "12px", marginBottom: "10px" }}>
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
                            <span style={{ color: "red", fontSize: "12px", marginBottom: "10px" }}>
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
                                border: errors.type ? "1px solid red" : "1px solid #ccc"
                            }}
                        >
                            <option value={1}>Despesa</option>
                            <option value={2}>Receita</option>
                        </select>
                        {errors.type && (
                            <span style={{ color: "red", fontSize: "12px", marginBottom: "10px" }}>
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
                                border: errors.personId ? "1px solid red" : "1px solid #ccc"
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
                            <span style={{ color: "red", fontSize: "12px", marginBottom: "10px" }}>
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
                                backgroundColor: filteredCategories.length === 0 ? "#f5f5f5" : "#fff",
                                cursor: filteredCategories.length === 0 ? "not-allowed" : "pointer"
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
                            <span style={{ color: "red", fontSize: "12px", marginBottom: "10px" }}>
                                {errors.categoryId}
                            </span>
                        )}

                        {filteredCategories.length === 0 && (
                            <span style={{ color: "#999", fontSize: "12px", marginBottom: "10px" }}>
                                Não há nenhuma categoria disponível para esse tipo de transação
                            </span>
                        )}
                    </div>

                    <div
                        style={{
                            display: "flex",
                            justifyContent: "flex-end",
                            gap: "10px",
                        }}
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