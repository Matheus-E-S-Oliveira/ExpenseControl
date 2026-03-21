import { useEffect, useState } from "react";
import { deletePerson, getPersons } from "../services/personService";
import PersonCard from "../components/PersonCard";
import PersonFilterCard from "../components/PersonFilterCard";
import MainLayout from "../../../layouts/MainLayout";
import PersonFormModal from "../components/PersonFormModal";
import ConfirmationModal from "../../../components/ConfirmationModal";
import ModalGlobal from "../../../components/ModalGlobal";

/**
 * Tipo Person usado no estado local
 */
type Person = { id: string; name: string; age: number };

/**
 * PersonsListPage - Página de listagem e gerenciamento de pessoas
 *
 * Lógica:
 * - Busca pessoas usando getPersons() ao montar o componente
 * - Permite filtrar por nome e idade via PersonFilterCard
 * - Permite criar e editar pessoas via PersonFormModal
 * - Permite excluir pessoas com confirmação via ConfirmationModal
 * - Exibe mensagens de sucesso/erro via ModalGlobal
 *
 * Estados principais:
 * - persons: lista de pessoas
 * - activePerson: pessoa atualmente sendo editada
 * - showFormModal: controla exibição do modal de cadastro/edição
 * - confirmId: id da pessoa a ser excluída (abre modal de confirmação)
 * - message / showMessage / success: mensagem global após ações
 * - hasFilter: indica se algum filtro está aplicado
 */
export default function PersonsListPage() {
  const [persons, setPersons] = useState<Person[]>([]);
  const [activePerson, setActivePerson] = useState<Person | null>(null);
  const [showFormModal, setShowFormModal] = useState(false);
  const [confirmId, setConfirmId] = useState<string | null>(null);
  const [message, setMessage] = useState("");
  const [showMessage, setShowMessage] = useState(false);
  const [success, setSuccess] = useState(true);
  const [hasFilter, setHasFilter] = useState(false);

  /**
   * Busca pessoas da API e aplica filtros opcionais
   */
  const fetchPersons = async (filters?: { name: string; age: string }) => {
    const response = await getPersons();
    let filtered = response.data;

    setHasFilter(!!filters);

    if (filters) {
      filtered = response.data.filter(
        (p: { name: string; age: number }) =>
          (!filters.name ||
            p.name.toLowerCase().includes(filters.name.toLowerCase())) &&
          (!filters.age || p.age === Number(filters.age)),
      );
    }
    setPersons(filtered);
  };

  /** Define id da pessoa a ser excluída, abre modal de confirmação */
  const handleDeleteClick = (id: string) => setConfirmId(id);

  /** Confirma exclusão da pessoa e atualiza lista */
  const handleConfirmDelete = async () => {
    if (!confirmId) return;

    try {
      const response = await deletePerson(confirmId);
      setMessage(response.message || "Pessoa excluída com sucesso!");
      setSuccess(true);
      setShowMessage(true);
      fetchPersons();
    } catch (error: any) {
      setMessage(error?.response?.data?.message || "Erro ao excluir a pessoa!");
      setSuccess(false);
      setShowMessage(true);
    } finally {
      setConfirmId(null);
    }
  };

  /** Cancela exclusão */
  const handleCancelDelete = () => setConfirmId(null);

  /** Abre modal para edição */
  const handleEdit = (person: Person) => {
    setActivePerson(person);
    setShowFormModal(true);
  };

  /** Abre modal para criação */
  const handleNew = () => {
    setActivePerson(null);
    setShowFormModal(true);
  };

  // Busca inicial de pessoas ao montar o componente
  useEffect(() => {
    fetchPersons();
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
        {/* Filtros e botão de criação */}
        <PersonFilterCard
          onSearch={fetchPersons}
          onClear={() => fetchPersons()}
          onNew={handleNew}
        />

        {/* Modal de cadastro/edição */}
        {showFormModal && (
          <PersonFormModal
            person={activePerson || undefined}
            onClose={() => setShowFormModal(false)}
            onSuccess={() => {
              fetchPersons();
              setShowFormModal(false);
            }}
          />
        )}

        {/* Lista de pessoas */}
        <div
          style={{
            display: "flex",
            flexWrap: "wrap",
            gap: "15px",
            justifyContent: "center",
            width: "100%",
          }}
        >
          {persons.length === 0 ? (
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
                ? "Nenhuma pessoa encontrada com esses filtros."
                : "Nenhuma pessoa cadastrada."}
            </div>
          ) : (
            persons.map((p) => (
              <PersonCard
                key={p.id}
                {...p}
                onDelete={handleDeleteClick}
                onEdit={handleEdit}
              />
            ))
          )}
        </div>

        {/* Modal de confirmação de exclusão */}
        {confirmId && (
          <ConfirmationModal
            message="Tem certeza que deseja excluir esta pessoa?"
            onConfirm={handleConfirmDelete}
            onCancel={handleCancelDelete}
          />
        )}

        {/* Modal global de mensagens */}
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