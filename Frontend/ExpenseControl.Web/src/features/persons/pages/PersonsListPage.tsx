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
  const [showModal, setShowModal] = useState(false);
  const [message, setMessage] = useState("");
  const [showMessage, setShowMessage] = useState(false);
  const [success, setSuccess] = useState(true);
  const [confirmId, setConfirmId] = useState<string | null>(null);
  const [editPerson, setEditPerson] = useState<{
    id: string;
    name: string;
    age: number;
  } | null>(null);

  const fetchPersons = async (filters?: { name: string; age: string }) => {
    const response = await getPersons();
    let filtered = response.data;
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

  const handleDeleteClick = (id: string) => {
    setConfirmId(id); // abre o modal de confirmação
  };

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

  const handleEdit = (person: { id: string; name: string; age: number }) => {
    setEditPerson(person);
  };

  const handleCancelDelete = () => {
    setConfirmId(null);
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
        }}
      >
        <PersonFilterCard
          onSearch={fetchPersons}
          onClear={() => fetchPersons()}
          onNew={() => setShowModal(true)}
        />
        {showModal && (
          <PersonFormModal
            onClose={() => setShowModal(false)}
            onSuccess={() => fetchPersons()}
          />
        )}
        {editPerson && (
          <PersonFormModal
            person={editPerson}
            onClose={() => setEditPerson(null)}
            onSuccess={() => {
              fetchPersons();
              setEditPerson(null);
            }}
          />
        )}
        <div
          style={{
            display: "flex",
            flexWrap: "wrap",
            gap: "15px",
            justifyContent: "center",
          }}
        >
          {persons.map((p) => (
            <PersonCard key={p.id} {...p} onDelete={handleDeleteClick} onEdit={handleEdit} />
          ))}
          {confirmId && (
            <ConfirmationModal
              message="Tem certeza que deseja excluir esta pessoa?"
              onConfirm={handleConfirmDelete}
              onCancel={handleCancelDelete}
            />
          )}
          {showMessage && (
            <ModalGlobal
              message={message}
              success={success}
              onClose={() => setShowMessage(false)}
            />
          )}
        </div>
      </div>
    </MainLayout>
  );
}
