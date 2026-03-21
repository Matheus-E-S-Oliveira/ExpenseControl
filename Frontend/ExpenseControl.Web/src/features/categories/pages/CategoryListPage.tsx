/**
 * CategoriesListPage - Página para listagem e gerenciamento de categorias
 *
 * Lógica:
 * - Utiliza hook useState e useEffect para gerenciar estados da lista e modais
 * - Busca categorias da API via getCategories
 * - Aplica filtros opcionais: descrição e propósito
 * - Exibe estados de carregamento e mensagem de sucesso
 * - Permite cadastrar nova categoria através de CategoryFormModal
 *
 * Estados:
 * - categories: lista de categorias
 * - showFormModal: controla exibição do modal de cadastro/edição
 * - message, showMessage, success: controle de feedback para o usuário
 * - hasFilter: indica se a lista foi filtrada
 *
 * Layout:
 * - Usa MainLayout
 * - Filtros com CategoryFilterCard
 * - Cards individuais de categorias com CategoryCard
 * - Modal global de mensagens (ModalGlobal)
 */
import { useEffect, useState } from "react";
import { getCategories } from "../services/categoryService";
import CategoryCard from "../components/CategoryCard";
import CategoryFilterCard from "../components/CategoryFilterCard";
import MainLayout from "../../../layouts/MainLayout";
import CategoryFormModal from "../components/CategoryFormModal";
import ModalGlobal from "../../../components/ModalGlobal";
import type { Category } from "../types/category";

export default function CategoriesListPage() {
  const [categories, setCategories] = useState<Category[]>([]);
  const [showFormModal, setShowFormModal] = useState(false);
  const [message, setMessage] = useState("");
  const [showMessage, setShowMessage] = useState(false);
  const [success, setSuccess] = useState(true);
  const [hasFilter, setHasFilter] = useState(false);

  /** Busca categorias e aplica filtros opcionais */
  const fetchCategories = async (filters?: {
    description: string;
    purpose: number | "";
  }) => {
    const response = await getCategories();
    let filtered = response.data;

    setHasFilter(!!filters);

    if (filters) {
      filtered = response.data.filter(
        (c: Category) =>
          (!filters.description ||
            c.description
              .toLowerCase()
              .includes(filters.description.toLowerCase())) &&
          (!filters.purpose || c.purpose === filters.purpose),
      );
    }

    setCategories(filtered);
  };

  /** Exibe modal para nova categoria */
  const handleNew = () => {
    setShowFormModal(true);
  };

  useEffect(() => {
    fetchCategories();
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
        <CategoryFilterCard
          onSearch={fetchCategories}
          onClear={() => fetchCategories()}
          onNew={handleNew}
        />

        {showFormModal && (
          <CategoryFormModal
            onClose={() => setShowFormModal(false)}
            onSuccess={() => {
              fetchCategories();
              setShowFormModal(false);
              setMessage("Categoria cadastrada com sucesso!");
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
          {categories.length === 0 ? (
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
                ? "Nenhuma categoria encontrada com esses filtros."
                : "Nenhuma categoria cadastrada."}
            </div>
          ) : (
            categories.map((c) => <CategoryCard key={c.id} {...c} />)
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