/**
 * PersonCard - Card individual de pessoa para listagem
 *
 * Props:
 * - id: identificador único da pessoa
 * - name: nome da pessoa
 * - age: idade da pessoa
 * - onDelete: função chamada ao clicar no ícone de excluir, recebe o id
 * - onEdit: função opcional chamada ao clicar no ícone de editar, recebe objeto { id, name, age }
 *
 * Lógica:
 * - Exibe nome e idade da pessoa
 * - Ícones de ação para editar (azul) e excluir (vermelho)
 * - Layout flex horizontal: texto à esquerda, ações à direita
 * - Texto cortado com ellipsis se for muito longo
 * - Caixa branca com bordas arredondadas, sombra e padding
 */
import { FiEdit, FiTrash2 } from "react-icons/fi";

type Props = {
  id: string;
  name: string;
  age: number;
  onDelete: (id: string) => void;
  onEdit?: (person: { id: string; name: string; age: number }) => void;
};

export default function PersonCard({ id, name, age, onDelete, onEdit }: Props) {
  return (
    <div
      style={{
        backgroundColor: "#fff",
        borderRadius: "10px",
        boxShadow: "rgba(0, 0, 0, 0.1) 0px 4px 8px",
        padding: "15px",
        width: "350px",
        display: "flex",
        justifyContent: "space-between",
        alignItems: "center",
        marginBottom: "15px",
      }}
    >
      <div style={{ flex: 1, marginRight: "10px", overflow: "hidden" }}>
        <div
          style={{
            fontWeight: "bold",
            fontSize: "16px",
            whiteSpace: "nowrap",
            textOverflow: "ellipsis",
            overflow: "hidden",
          }}
        >
          {name}
        </div>
        <div style={{ fontSize: "14px", color: "#666" }}>{age} anos</div>
      </div>
      <div style={{ display: "flex", gap: "8px" }}>
        <FiEdit
          size={18}
          color="#0080FF"
          cursor="pointer"
          onClick={() => onEdit && onEdit({ id, name, age })}
        />
        <button
          onClick={() => onDelete(id)}
          style={{ background: "none", border: "none", cursor: "pointer" }}
        >
          <FiTrash2 size={18} color="#FF4D4F" />
        </button>
      </div>
    </div>
  );
}