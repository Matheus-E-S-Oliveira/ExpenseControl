import { useState } from "react";
import { createCategory } from "../services/categoryService";
import ModalGlobal from "../../../components/ModalGlobal";

type Props = {
    onClose: () => void;
    onSuccess: () => void;
};

export default function CategoryFormModal({ onClose, onSuccess }: Props) {
    const [description, setDescription] = useState("");
    const [purpose, setPurpose] = useState<number>(1);
    const [message, setMessage] = useState("");
    const [showMessage, setShowMessage] = useState(false);
    const [success, setSuccess] = useState(true);
    const [loading, setLoading] = useState(false);

    const [errors, setErrors] = useState<any>({});

    const handleSubmit = async () => {
        setLoading(true);

        const isValid = validateCategory();

        if (!isValid) {
            setLoading(false);
            return;
        }

        try {
            const response = await createCategory({
                description,
                purpose,
            });

            onSuccess();
            onClose();

            setTimeout(() => {
                setMessage(response.message || "Categoria cadastrada com sucesso!");
                setSuccess(true);
                setShowMessage(true);
            }, 100);

        } catch (error: any) {
            setMessage(error?.response?.data?.message || "Erro ao salvar categoria!");
            setSuccess(false);
            setShowMessage(true);
        } finally {
            setLoading(false);
        }
    };

    const validateCategory = () => {
        const errors: any = {};

        if (!description.trim()) {
            errors.description = "Descrição é obrigatória";
        } else if (description.length > 400) {
            errors.description = "Máximo de 400 caracteres";
        }

        if (!purpose) {
            errors.purpose = "Selecione a finalidade";
        }

        setErrors(errors);
        return Object.keys(errors).length === 0;
    };

    return (
        <>
            {/* Overlay */}
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
                {/* Modal */}
                <div
                    style={{
                        backgroundColor: "#fff",
                        padding: "20px",
                        borderRadius: "10px",
                        minWidth: "400px",
                    }}
                >
                    <h2>Cadastrar Categoria</h2>

                    <div style={{ display: "flex", flexDirection: "column" }}>
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

                        <select
                            value={purpose}
                            onChange={(e) => {
                                setPurpose(Number(e.target.value));
                                setErrors((prev: any) => ({ ...prev, purpose: "" }));
                            }}
                            style={{
                                width: "100%",
                                padding: "8px",
                                marginBottom: "5px",
                                border: errors.purpose ? "1px solid red" : "1px solid #ccc"
                            }}
                        >
                            <option value={1}>Despesa</option>
                            <option value={2}>Receita</option>
                            <option value={3}>Ambos</option>
                        </select>

                        {errors.purpose && (
                            <span style={{ color: "red", fontSize: "12px", marginBottom: "10px" }}>
                                {errors.purpose}
                            </span>
                        )}
                    </div>

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

            {/* Modal de mensagem */}
            {showMessage && (
                <ModalGlobal
                    message={message}
                    success={success}
                    onClose={() => {
                        setShowMessage(false);
                        onSuccess(); // atualiza lista
                        onClose();   // fecha modal
                    }}
                />
            )}
        </>
    );
}