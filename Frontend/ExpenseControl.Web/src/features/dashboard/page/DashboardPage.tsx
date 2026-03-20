import MainLayout from "../../../layouts/MainLayout";
import useDashboard from "../hook/useDashboard";

export default function DashboardPage() {
  const { data, loading, error } = useDashboard();

  if (loading) return <MainLayout>Loading...</MainLayout>;
  if (error) return <MainLayout>{error}</MainLayout>;
  if (!data) return null;

  const balanceColor =
    data.balance > 0 ? "#10b981" : data.balance < 0 ? "#ef4444" : "#f59e0b";

  const cardStyle = (type: "income" | "expense" | "balance") => {
    let borderColor = type === "income" ? "#10b981" : type === "expense" ? "#ef4444" : "#f59e0b";
    return {
      flex: 1,
      minWidth: 150,
      padding: 20,
      borderRadius: 12,
      borderLeft: `6px solid ${borderColor}`,
      backgroundColor: "#fff",
      boxShadow: "0 2px 12px rgba(0,0,0,0.1)",
      display: "flex",
      flexDirection: "column" as const,
      justifyContent: "center",
      alignItems: "flex-start",
    };
  };

  const groupStyle = {
    background: "#fff",
    padding: "12px 16px",
    borderRadius: 8,
    marginBottom: 12,
    flex: 1,
    border: "1px solid #f1f5f9",
  };

  const groupItemStyle = {
    background: "rgb(254, 252, 232)",
    padding: "8px 12px",
    borderRadius: 6,
    marginBottom: 8,
    fontSize: 14,
    color: "#475569",
    display: "grid",
    gridTemplateColumns: "2fr 1fr 1fr 1fr",
    gap: 12,
    alignItems: "center",
    listStyle: "none" as const,
  };

  const groupTitleStyle = { fontSize: 14, fontWeight: 600, marginBottom: 6, color: "#334155" };

  return (
    <MainLayout>
      <div style={{ display: "flex", flexDirection: "column", marginTop: 20, marginBottom: 30, width: "100%" }}>
        <h1 style={{ fontSize: 28, color: "#333", marginBottom: 20 }}>Dashboard</h1>

        <div
          style={{
            display: "grid",
            gridTemplateColumns: "1fr 1fr",
            gap: 20,
            minHeight: 400,
          }}
        >
          {/* Column A */}
          <div style={{ display: "flex", flexDirection: "column", gap: 20 }}>
            {/* General Summary */}
            <div style={{ backgroundColor: "#fff", padding: 20, borderRadius: 12, boxShadow: "0 2px 12px rgba(0,0,0,0.1)" }}>
              <h2 style={{ marginTop: 0 }}>Resumo Geral</h2>
              <div style={{ display: "flex", gap: 20, flexWrap: "wrap" }}>
                <div style={cardStyle("income")}>
                  <h3 style={{ color: "#10b981", margin: 0 }}>Receita Total</h3>
                  <p style={{ fontWeight: "bold", margin: "6px 0" }}>
                    R$ {data.totalIncome.toLocaleString("pt-BR", { minimumFractionDigits: 2, maximumFractionDigits: 2 })}
                  </p>
                </div>
                <div style={cardStyle("expense")}>
                  <h3 style={{ color: "#ef4444", margin: 0 }}>Despesa Total</h3>
                  <p style={{ fontWeight: "bold", margin: "6px 0" }}>
                    R$ {data.totalExpenses.toLocaleString("pt-BR", { minimumFractionDigits: 2, maximumFractionDigits: 2 })}
                  </p>
                </div>
                <div style={cardStyle("balance")}>
                  <h3 style={{ color: balanceColor, margin: 0 }}>Saldo</h3>
                  <p style={{ fontWeight: "bold", margin: "6px 0", color: balanceColor }}>
                    R$ {data.balance.toLocaleString("pt-BR", { minimumFractionDigits: 2, maximumFractionDigits: 2 })}
                  </p>
                </div>
              </div>
            </div>

            {/* People */}
            <div style={{ backgroundColor: "#fff", padding: 20, borderRadius: 12, boxShadow: "0 2px 12px rgba(0,0,0,0.1)" }}>
              <h2 style={{ marginTop: 0, marginBottom: 12 }}>Pessoas</h2>
              <p>Total de pessoas registradas: {data.people.length}</p>
              <div style={groupStyle}>
                <h3 style={groupTitleStyle}>Situação por pessoa</h3>
                <ul style={{ margin: 0, padding: 0 }}>
                  {data.people.map((p, i) => (
                    <li key={i} style={{ ...groupItemStyle, justifyContent: 'space-between', flexWrap: 'wrap' }}>
                      <span>{p.name} ({p.age} anos)</span>
                      <span>Receita: R$ {p.totalIncome.toLocaleString("pt-BR", { minimumFractionDigits: 2, maximumFractionDigits: 2 })}</span>
                      <span>Gastos: R$ {p.totalExpenses.toLocaleString("pt-BR", { minimumFractionDigits: 2, maximumFractionDigits: 2 })}</span>
                      <span>Saldo: R$ {p.balance.toLocaleString("pt-BR", { minimumFractionDigits: 2, maximumFractionDigits: 2 })}</span>
                    </li>
                  ))}
                </ul>
              </div>
            </div>
          </div>

          {/* Column B */}
          <div style={{ display: "flex", flexDirection: "column", gap: 20 }}>
            {/* Categories */}
            <div style={{ backgroundColor: "#fff", padding: 20, borderRadius: 12, boxShadow: "0 2px 12px rgba(0,0,0,0.1)" }}>
              <h2 style={{ marginTop: 0, marginBottom: 12 }}>Categorias</h2>
              <p>Total de pessoas registradas: {data.categories.length}</p>
              <div style={groupStyle}>
                <ul style={{ margin: 0, padding: 0 }}>
                  {data.categories.map((c, i) => (
                    <li key={i} style={{ ...groupItemStyle, gridTemplateColumns: "3fr 1fr 1fr 1fr" }}>
                      <span>{c.description}</span>
                      <span>Receita: R$ {c.totalIncome.toLocaleString("pt-BR", { minimumFractionDigits: 2, maximumFractionDigits: 2 })}</span>
                      <span>Gastos: R$ {c.totalExpenses.toLocaleString("pt-BR", { minimumFractionDigits: 2, maximumFractionDigits: 2 })}</span>
                      <span>Saldo: R$ {c.balance.toLocaleString("pt-BR", { minimumFractionDigits: 2, maximumFractionDigits: 2 })}</span>
                    </li>
                  ))}
                </ul>
              </div>
            </div>

            {/* Recent Transactions */}
            <div style={{ backgroundColor: "#fff", padding: 20, borderRadius: 12, boxShadow: "0 2px 12px rgba(0,0,0,0.1)" }}>
              <h2 style={{ marginTop: 0, marginBottom: 12 }}>Transações Recentes</h2>
              <div style={groupStyle}>
                <ul style={{ margin: 0, padding: 0 }}>
                  {(data.recentTransactions || []).map((t, i) => (
                    <li
                      key={i}
                      style={{
                        ...groupItemStyle,
                        display: "grid",
                        gridTemplateColumns: "1fr 2fr 1fr 1fr",
                        gap: "12px",
                        alignItems: "center",
                      }}
                    >
                      <span>Autor: {t.personName}</span>
                      <span>{t.description}</span>
                      {/* Breadcrumb-like */}
                      <span
                        style={{
                          fontWeight: "bold",
                          textAlign: "end",
                          color: t.type === 1 ? "#10b981" : "#ef4444",
                        }}
                      >
                        {t.type === 1
                          ? `+ R$ ${t.value.toLocaleString("pt-BR", { minimumFractionDigits: 2, maximumFractionDigits: 2 })}`
                          : `- R$ ${t.value.toLocaleString("pt-BR", { minimumFractionDigits: 2, maximumFractionDigits: 2 })}`}
                      </span>
                      <span
                        style={{
                          backgroundColor: "#f0f0f0",
                          padding: "2px 8px",
                          borderRadius: "6px",
                          fontWeight: 600,
                          display: "inline-block",
                          textAlign: "center",
                        }}
                      >
                        {t.type === 1 ? "Receita" : "Despesa"}
                      </span>
                      {/* Valor com estilo condicional */}
                    </li>
                  ))}
                </ul>
              </div>
            </div>
          </div>
        </div>
      </div>
    </MainLayout>
  );
}