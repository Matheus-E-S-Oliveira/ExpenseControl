
type Props = {
    id: string;
    description: string;
    purpose: number;
};

const getPurposeLabel = (purpose: number) => {
    switch (purpose) {
        case 1: return "Despesa";
        case 2: return "Receita";
        case 3: return "Ambos";
    }
};

export default function CategoryCard({
    // id,
    description,
    purpose,
}: Props) {
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
                    {description}
                </div>

                <div style={{ fontSize: "14px", color: "#666" }}>
                    {getPurposeLabel(purpose)}
                </div>
            </div>

            {/* <div style={{ display: "flex", gap: "8px" }}>
                <Link to={`/category/details/${id}`}>
                    <FiEye size={18} color="#40A9FF" cursor="pointer" />
                </Link>
            </div> */}
        </div>
    );
}