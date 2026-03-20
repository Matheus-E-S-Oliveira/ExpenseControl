import { useEffect, useState } from "react";
import { deletePerson, getPersons } from "../services/personService";
import PersonCard from "../components/PersonCard";
import PersonFilterCard from "../components/PersonFilterCard";
import MainLayout from "../../../layouts/MainLayout";
import PersonFormModal from "../components/PersonFormModal";
import ConfirmationModal from "../../../components/ConfirmationModal";
import ModalGlobal from "../../../components/ModalGlobal";

type Person = { id: string; name: string; age: number };

export default function PersonsListPage() {
  const [persons, setPersons] = useState<Person[]>([]);
  const [activePerson, setActivePerson] = useState<Person | null>(null);
  const [showFormModal, setShowFormModal] = useState(false);
  const [confirmId, setConfirmId] = useState<string | null>(null);
  const [message, setMessage] = useState("");
  const [showMessage, setShowMessage] = useState(false);
  const [success, setSuccess] = useState(true);
  const [hasFilter, setHasFilter] = useState(false);

  const fetchPersons = async (filters?: { name: string; age: string }) => {
    const response = await getPersons();
    let filtered = response.data;

    setHasFilter(!!filters);

    if (filters) {
      filtered = response.data.filter(
        (p: { name: string; age: number }) =>
          (!filters.name ||
            p.name.toLowerCase().includes(filters.name.toLowerCase())) &&
          (!filters.age || p.age === Number(filters.age))
      );
    }
    setPersons(filtered);
  };

  // Exclusão
  const handleDeleteClick = (id: string) => setConfirmId(id);

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

  const handleCancelDelete = () => setConfirmId(null);

  const handleEdit = (person: Person) => {
    setActivePerson(person);
    setShowFormModal(true);
  };

  const handleNew = () => {
    setActivePerson(null);
    setShowFormModal(true);
  };

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
        <PersonFilterCard
          onSearch={fetchPersons}
          onClear={() => fetchPersons()}
          onNew={handleNew}
        />

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