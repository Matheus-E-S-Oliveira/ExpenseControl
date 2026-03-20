type Props = {
  id: string;
  description: string;
  value: number;
  type: number;
  person?: { name: string; age?: number };
  category?: { description: string };
};

const isExpense = (type: number) => type === 1;

const getTypeLabel = (type: number) => {
  return isExpense(type) ? "Despesa" : "Receita";
};

const getTypeColor = (type: number) => {
  return isExpense(type) ? "#FF4D4F" : "#00C853";
};

const getTypeBackground = (type: number) => {
  return isExpense(type) ? "#FFF1F0" : "#E8F5E9";
};

export default function TransactionCard({
  description,
  value,
  type,
  person,
  category,
}: Props) {
  const color = getTypeColor(type);

  return (
    <div
      style={{
        backgroundColor: "#fff",
        borderRadius: "10px",
        boxShadow: "rgba(0,0,0,0.1) 0px 4px 8px",
        padding: "15px",
        width: "350px",
        display: "flex",
        flexDirection: "column",
        gap: "10px",
        borderLeft: `6px solid ${color}`,
      }}
    >
      {/* Header (Descrição + Badge) */}
      <div style={{ display: "flex", justifyContent: "space-between" }}>
        <div
          style={{
            fontWeight: "bold",
            fontSize: "16px",
            whiteSpace: "nowrap",
            textOverflow: "ellipsis",
            overflow: "hidden",
            maxWidth: "70%",
          }}
        >
          {description}
        </div>

        {/* Badge tipo */}
        <div
          style={{
            backgroundColor: getTypeBackground(type),
            color: color,
            padding: "4px 8px",
            borderRadius: "20px",
            fontSize: "12px",
            fontWeight: "bold",
          }}
        >
          {getTypeLabel(type)}
        </div>
      </div>

      {/* Valor */}
      <div style={{ fontSize: "14px" }}>
        Valor:{" "}
        <strong style={{ color }}>
          R$ {value.toFixed(2)}
        </strong>
      </div>

      {/* Tipo (reforçado visualmente) */}
      <div style={{ fontSize: "14px" }}>
        Tipo:{" "}
        <strong style={{ color }}>
          {getTypeLabel(type)}
        </strong>
      </div>

      {/* Pessoa */}
      <div style={{ fontSize: "14px", color: "#666" }}>
        Pessoa:{" "}
        {person
          ? `${person.name}${person.age ? ` (${person.age} anos)` : ""}`
          : "-"}
      </div>

      {/* Categoria */}
      <div style={{ fontSize: "14px", color: "#666" }}>
        Categoria: {category?.description || "-"}
      </div>
    </div>
  );
}