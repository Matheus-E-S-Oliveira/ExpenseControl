import { useEffect, useState } from "react";
import MainLayout from "../../../layouts/MainLayout";
import ModalGlobal from "../../../components/ModalGlobal";
import TransactionCard from "../components/TransactionCard";
import TransactionFilterCard from "../components/TransactionFilterCard";
import TransactionFormModal from "../components/TransactionFormModal";
import { getTransactions } from "../services/transactionService";
import type { Transaction } from "../types/transaction";


export default function TransactionsListPage() {
    const [transactions, setTransactions] = useState<Transaction[]>([]);
    const [showFormModal, setShowFormModal] = useState(false);
    const [message, setMessage] = useState("");
    const [showMessage, setShowMessage] = useState(false);
    const [success, setSuccess] = useState(true);
    const [hasFilter, setHasFilter] = useState(false);

    const fetchTransactions = async (filters?: {
        description: string;
        type: number | "";
        personName: string;
        category: string;
    }) => {
        const response = await getTransactions();
        let filtered = response.data;

        setHasFilter(!!filters);

        if (filters) {
            filtered = response.data.filter((t: Transaction) =>
                (!filters.description ||
                    t.description.toLowerCase().includes(filters.description.trim().toLowerCase())) &&

                (!filters.type || t.type === filters.type) &&

                (!filters.personName ||
                    t.person?.name?.toLowerCase().includes(filters.personName.toLowerCase())) &&

                (!filters.category ||
                    t.category?.description?.toLowerCase().includes(filters.category.toLowerCase()))
            );
        }

        setTransactions(filtered);
    };

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

                <TransactionFilterCard
                    onSearch={fetchTransactions}
                    onClear={() => fetchTransactions()}
                    onNew={() => setShowFormModal(true)}
                />

                {showFormModal && (
                    <TransactionFormModal
                        onClose={() => setShowFormModal(false)}
                        onSuccess={() => {
                            fetchTransactions();
                            setShowFormModal(false);
                            setMessage("Transação cadastrada com sucesso!");
                            setSuccess(true);
                            setShowMessage(true);
                        }}
                    />
                )}

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
                        transactions.map((t) => (
                            <TransactionCard key={t.id} {...t} />
                        ))
                    )}
                </div>

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