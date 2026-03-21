import { useEffect, useState } from "react";
import MainLayout from "../../../layouts/MainLayout";
import ModalGlobal from "../../../components/ModalGlobal";
import TransactionCard from "../components/TransactionCard";
import TransactionFilterCard from "../components/TransactionFilterCard";
import TransactionFormModal from "../components/TransactionFormModal";
import { getTransactions } from "../services/transactionService";
import type { Transaction } from "../types/transaction";

/**
 * TransactionsListPage
 *
 * Página principal para exibição e gerenciamento das transações financeiras.
 * Permite:
 *  - Listar todas as transações cadastradas
 *  - Filtrar transações por descrição, tipo, pessoa ou categoria
 *  - Abrir modal para criar nova transação
 *  - Feedback visual ao usuário (sucesso ou erro)
 */
export default function TransactionsListPage() {
  // Estado que guarda a lista de transações exibidas
  const [transactions, setTransactions] = useState<Transaction[]>([]);

  // Controla a abertura do modal de cadastro de transações
  const [showFormModal, setShowFormModal] = useState(false);

  // Mensagem de feedback ao usuário
  const [message, setMessage] = useState("");

  // Controla visibilidade do modal de mensagem
  const [showMessage, setShowMessage] = useState(false);

  // Define se a operação foi bem-sucedida (true) ou falhou (false)
  const [success, setSuccess] = useState(true);

  // Indica se filtros estão sendo aplicados na listagem
  const [hasFilter, setHasFilter] = useState(false);

  /**
   * fetchTransactions
   *
   * Função responsável por buscar todas as transações da API e aplicar filtros, caso existam.
   *
   * @param filters - Objeto opcional com filtros:
   *    description: string - filtro por descrição da transação
   *    type: number | "" - filtro por tipo de transação (1: despesa, 2: receita)
   *    personName: string - filtro por nome da pessoa associada
   *    category: string - filtro por descrição da categoria
   */
  const fetchTransactions = async (filters?: {
    description: string;
    type: number | "";
    personName: string;
    category: string;
  }) => {
    const response = await getTransactions(); // busca todas as transações da API
    let filtered = response.data;

    setHasFilter(!!filters); // define se há filtros ativos

    if (filters) {
      // aplica filtros de forma condicional
      filtered = response.data.filter(
        (t: Transaction) =>
          (!filters.description ||
            t.description
              .toLowerCase()
              .includes(filters.description.trim().toLowerCase())) &&
          (!filters.type || t.type === filters.type) &&
          (!filters.personName ||
            t.person?.name
              ?.toLowerCase()
              .includes(filters.personName.toLowerCase())) &&
          (!filters.category ||
            t.category?.description
              ?.toLowerCase()
              .includes(filters.category.toLowerCase())),
      );
    }

    setTransactions(filtered); // atualiza o estado com a lista filtrada
  };

  // Carrega todas as transações ao inicializar a página
  useEffect(() => {
    fetchTransactions();
  }, []);

  return (
    <MainLayout>
      <div
        style={{
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
          gap: "20px",
          width: "100%",
        }}
      >
        {/* Componente de filtro e botão de nova transação */}
        <TransactionFilterCard
          onSearch={fetchTransactions} // callback para aplicar filtros
          onClear={() => fetchTransactions()} // limpa filtros e recarrega lista
          onNew={() => setShowFormModal(true)} // abre modal de nova transação
        />

        {/* Modal para criar nova transação */}
        {showFormModal && (
          <TransactionFormModal
            onClose={() => setShowFormModal(false)} // fecha modal
            onSuccess={() => {
              // atualiza lista e mostra feedback de sucesso
              fetchTransactions();
              setShowFormModal(false);
              setMessage("Transação cadastrada com sucesso!");
              setSuccess(true);
              setShowMessage(true);
            }}
          />
        )}

        {/* Lista de cards de transações */}
        <div
          style={{
            display: "flex",
            flexWrap: "wrap",
            gap: "15px",
            justifyContent: "center",
            width: "100%",
          }}
        >
          {transactions.length === 0 ? (
            // Mensagem caso não haja transações ou filtros não retornem resultados
            <div
              style={{
                width: "100%",
                textAlign: "center",
                padding: "30px",
                color: "#666",
                fontSize: "16px",
              }}
            >
              {hasFilter
                ? "Nenhuma transação encontrada com esses filtros."
                : "Nenhuma transação cadastrada."}
            </div>
          ) : (
            // Renderiza um card para cada transação
            transactions.map((t) => <TransactionCard key={t.id} {...t} />)
          )}
        </div>

        {/* Modal de feedback */}
        {showMessage && (
          <ModalGlobal
            message={message}
            success={success}
            onClose={() => setShowMessage(false)}
          />
        )}
      </div>
    </MainLayout>
  );
}