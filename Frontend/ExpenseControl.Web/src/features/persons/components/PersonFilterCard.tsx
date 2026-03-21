/**
 * PersonFilterCard - Card de filtros e ações para lista de pessoas
 *
 * Props:
 * - onSearch: função chamada ao clicar em Buscar, recebe filtros { name, age }
 * - onClear: função chamada ao clicar em Limpar, reseta inputs e filtros
 * - onNew: função chamada ao clicar em Novo, abre modal de criação
 *
 * Lógica:
 * - Mantém estados locais para `name` e `age`
 * - `handleSearch` envia os filtros para o componente pai
 * - `handleClear` limpa os inputs e chama `onClear`
 * - Botões estilizados com cores distintas e ícones (react-icons/fi)
 * - Inputs são responsivos e alinhados em flex wrap
 * - Layout com caixa branca, bordas arredondadas, sombra e espaçamento interno
 */
import { useState } from "react";
import { FiPlus, FiSearch, FiX } from "react-icons/fi";

type Props = {
  onSearch: (filters: { name: string; age: string }) => void;
  onClear: () => void;
  onNew: () => void;
};

export default function PersonFilterCard({ onSearch, onClear, onNew }: Props) {
  const [name, setName] = useState("");
  const [age, setAge] = useState("");

  const handleSearch = () => onSearch({ name, age });
  const handleClear = () => {
    setName("");
    setAge("");
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
      <h2 style={{ margin: 0 }}>Lista de Pessoas</h2>
      <div style={{ display: "flex", gap: "10px", flexWrap: "wrap" }}>
        <input
          type="text"
          placeholder="Nome"
          value={name}
          onChange={(e) => setName(e.target.value)}
          style={{
            flex: 1,
            padding: "8px",
            borderRadius: "5px",
            border: "1px solid #ccc",
          }}
        />
        <input
          type="number"
          placeholder="Idade"
          value={age}
          onChange={(e) => setAge(e.target.value)}
          style={{
            width: "400px",
            padding: "8px",
            borderRadius: "5px",
            border: "1px solid #ccc",
          }}
        />
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
          <FiPlus /> Novo
        </button>
      </div>
    </div>
  );
}