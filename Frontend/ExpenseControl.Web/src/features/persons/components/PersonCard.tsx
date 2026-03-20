import { FiEdit, FiTrash2, FiEye } from "react-icons/fi";
import { Link } from "react-router-dom";

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
        <Link to={`/person/details/${id}`}>
          <FiEye size={18} color="#40A9FF" cursor={"pointer"} />
        </Link>
      </div>
    </div>
  );
}
