import Card from "../../../components/Card";
import MainLayout from "../../../layouts/MainLayout";

export default function DashboardPage() {
  return (
    <MainLayout>
      <Card title="Resumo de Pessoas">
        <p>Total de pessoas cadastradas: 10</p>
        <p>Total de receitas: R$ 12.000</p>
        <p>Total de despesas: R$ 8.000</p>
      </Card>

      <Card title="Resumo de Categorias">
        <p>Categoria A: R$ 5.000</p>
        <p>Categoria B: R$ 3.000</p>
      </Card>

      <Card title="Resumo de Transações">
        <p>Últimas transações:</p>
        <ul>
          <li>Compra X - R$ 100</li>
          <li>Venda Y - R$ 250</li>
        </ul>
      </Card>
    </MainLayout>
  );
}
