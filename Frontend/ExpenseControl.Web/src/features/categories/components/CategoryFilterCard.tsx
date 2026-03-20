import { useState } from "react";
import { FiPlus, FiSearch, FiX } from "react-icons/fi";

type Props = {
    onSearch: (filters: { description: string; purpose: number | "" }) => void;
    onClear: () => void;
    onNew: () => void;
};

export default function CategoryFilterCard({ onSearch, onClear, onNew }: Props) {
    const [description, setDescription] = useState("");
    const [purpose, setPurpose] = useState<number | "">("");

    const handleSearch = () => onSearch({ description, purpose });

    const handleClear = () => {
        setDescription("");
        setPurpose("");
        onClear();
    };

    return (
        <div
            style={{
                backgroundColor: "#fff",
                borderRadius: "10px",
                boxShadow: "rgba(0, 0, 0, 0.1) 0px 4px 8px",
                padding: "20px",
                marginBottom: "20px",
                display: "flex",
                flexDirection: "column",
                gap: "15px",
                width: "100%",
                marginTop: "40px",
                boxSizing: "border-box",
            }}
        >
            <h2 style={{ margin: 0 }}>Lista de Categorias</h2>

            <div style={{ display: "flex", gap: "10px", flexWrap: "wrap" }}>
                <input
                    type="text"
                    placeholder="Descrição"
                    value={description}
                    onChange={(e) => setDescription(e.target.value)}
                    style={{
                        flex: 1,
                        padding: "8px",
                        borderRadius: "5px",
                        border: "1px solid #ccc",
                    }}
                />

                <select
                    value={purpose}
                    onChange={(e) =>
                        setPurpose(e.target.value === "" ? "" : Number(e.target.value))
                    }
                    style={{
                        width: "400px",
                        padding: "8px",
                        borderRadius: "5px",
                        border: "1px solid #ccc",
                    }}
                >
                    <option value="">Todos os propósitos</option>
                    <option value={1}>Despesa</option>
                    <option value={2}>Receita</option>
                    <option value={3}>Ambos</option>
                </select>
            </div>

            <div
                style={{
                    display: "flex",
                    gap: "10px",
                    flexWrap: "wrap",
                    justifyContent: "flex-end",
                }}
            >
                <button
                    onClick={handleSearch}
                    style={{
                        padding: "8px 12px",
                        borderRadius: "5px",
                        backgroundColor: "#0080FF",
                        color: "#fff",
                        border: "none",
                        alignItems: "center",
                        display: "flex",
                        gap: "5px",
                        fontSize: "15px",
                        cursor: "pointer",
                    }}
                >
                    <FiSearch /> Buscar
                </button>

                <button
                    onClick={handleClear}
                    style={{
                        padding: "8px 12px",
                        borderRadius: "5px",
                        backgroundColor: "#aaa",
                        color: "#fff",
                        border: "none",
                        alignItems: "center",
                        display: "flex",
                        gap: "5px",
                        fontSize: "15px",
                        cursor: "pointer",
                    }}
                >
                    <FiX /> Limpar
                </button>

                <button
                    onClick={onNew}
                    style={{
                        padding: "8px 12px",
                        borderRadius: "5px",
                        backgroundColor: "#00C853",
                        color: "#fff",
                        border: "none",
                        alignItems: "center",
                        display: "flex",
                        gap: "5px",
                        fontSize: "15px",
                        cursor: "pointer",
                    }}
                >
                    <FiPlus /> Nova
                </button>
            </div>
        </div>
    );
}