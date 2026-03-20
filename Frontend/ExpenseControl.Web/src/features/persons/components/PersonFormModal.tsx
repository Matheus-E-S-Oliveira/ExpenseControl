import { useState } from "react";
import { createPerson, updatePerson } from "../services/personService";
import ModalGlobal from "../../../components/ModalGlobal";

type Props = {
  onClose: () => void;
  onSuccess: () => void;
  person?: { id: string; name: string; age: number };
};

export default function PersonFormModal({ onClose, onSuccess, person }: Props) {
  const [name, setName] = useState(person?.name || "");
  const [age, setAge] = useState(person?.age.toString() || "");
  const [message, setMessage] = useState("");
  const [showMessage, setShowMessage] = useState(false);
  const [success, setSuccess] = useState(true);

  const handleSubmit = async () => {
    try {
      if (person) {
        const response = await updatePerson(person.id, { name, age: Number(age) });
        setMessage(response.message || "Pessoa atualizada com sucesso!");
      } else {
        const response = await createPerson({ name, age: Number(age) });
        setMessage(response.message || "Pessoa cadastrada com sucesso!");
      }
      setSuccess(true);
      setShowMessage(true);
      onSuccess();
      onClose();
    } catch (error: any) {
      setMessage(error?.response?.data?.message || "Erro ao cadastrar!");
      setSuccess(false);
      setShowMessage(true);
    }
  };

  return (
    <>
      <div
        style={{
          position: "fixed",
          top: 0,
          left: 0,
          right: 0,
          bottom: 0,
          backgroundColor: "rgba(0,0,0,0.4)",
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
          zIndex: 999,
        }}
      >
        <div
          style={{
            backgroundColor: "#fff",
            padding: "20px",
            borderRadius: "10px",
            minWidth: "400px",
          }}
        >
          <h2>Cadastrar Pessoa</h2>
          <div style={{ display: "flex", flexDirection: "column" }}>
            <input
              type="text"
              placeholder="Nome"
              value={name}
              onChange={(e) => setName(e.target.value)}
              style={{ width: "94%", padding: "8px", marginBottom: "10px" }}
            />
            <input
              type="number"
              placeholder="Idade"
              value={age}
              onChange={(e) => setAge(e.target.value)}
              style={{ width: "94%", padding: "8px", marginBottom: "10px" }}
            />
          </div>
          <div
            style={{ display: "flex", justifyContent: "flex-end", gap: "10px" }}
          >
            <button
              onClick={onClose}
              style={{
                backgroundColor: "#aaa",
                color: "#fff",
                border: "none",
                padding: "10px",
                borderRadius: "5px",
                cursor: "pointer",
              }}
            >
              Cancelar
            </button>
            <button
              onClick={handleSubmit}
              style={{
                backgroundColor: "#0080FF",
                color: "#fff",
                border: "none",
                padding: "10px",
                borderRadius: "5px",
                cursor: "pointer",
              }}
            >
              Salvar
            </button>
          </div>
        </div>
      </div>

      {showMessage && (
        <ModalGlobal
          message={message}
          success={success}
          onClose={() => setShowMessage(false)}
        />
      )}
    </>
  );
}
