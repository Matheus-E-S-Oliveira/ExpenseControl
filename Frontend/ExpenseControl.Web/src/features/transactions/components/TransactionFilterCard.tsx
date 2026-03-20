import { useState } from "react";
import { FiSearch, FiX, FiPlus } from "react-icons/fi";

type Props = {
  onSearch: (filters: {
    description: string;
    type: number | "";
    personName: string;
    category: string;
  }) => void;
  onClear: () => void;
  onNew: () => void;
};

export default function TransactionFilterCard({ onSearch, onClear, onNew }: Props) {
  const [description, setDescription] = useState("");
  const [type, setType] = useState<number | "">("");
  const [personName, setPersonName] = useState("");
  const [category, setCategory] = useState("");

  const handleSearch = () =>
    onSearch({ description, type, personName, category });

  const handleClear = () => {
    setDescription("");
    setType("");
    setPersonName("");
    setCategory("");
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
        boxSizing: 'border-box'
      }}
    >
      <h2 style={{ margin: 0 }}>Lista de Transações</h2>

      {/* Campos */}
      <div style={{ display: "flex", gap: "10px", flexWrap: "wrap" }}>
        <input
          placeholder="Descrição"
          value={description}
          onChange={(e) => setDescription(e.target.value)}
          style={{ flex: 1, padding: "8px", borderRadius: "5px", border: "1px solid #ccc" }}
        />

        <input
          placeholder="Pessoa"
          value={personName}
          onChange={(e) => setPersonName(e.target.value)}
          style={{ flex: 1, padding: "8px", borderRadius: "5px", border: "1px solid #ccc" }}
        />

        <input
          placeholder="Categoria"
          value={category}
          onChange={(e) => setCategory(e.target.value)}
          style={{ flex: 1, padding: "8px", borderRadius: "5px", border: "1px solid #ccc" }}
        />

        <select
          value={type}
          onChange={(e) =>
            setType(e.target.value === "" ? "" : Number(e.target.value))
          }
          style={{
            width: "200px",
            padding: "8px",
            borderRadius: "5px",
            border: "1px solid #ccc",
          }}
        >
          <option value="">Todos os tipos</option>
          <option value={1}>Despesa</option>
          <option value={2}>Receita</option>
        </select>
      </div>

      {/* Botões */}
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
            display: "flex",
            gap: "5px",
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
            display: "flex",
            gap: "5px",
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
            display: "flex",
            gap: "5px",
            cursor: "pointer",
          }}
        >
          <FiPlus /> Nova
        </button>
      </div>
    </div>
  );
}