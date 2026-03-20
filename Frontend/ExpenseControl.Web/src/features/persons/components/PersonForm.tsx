import React, { useState } from "react";
import { createPerson } from "../services/personService";

type Props = {
  onPersonCreated: () => void;
};

export default function PersonForm({ onPersonCreated }: Props) {
  const [name, setName] = useState("");
  const [age, setAge] = useState("");

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!name || !age) return;
    await createPerson({ name, age: Number(age) });
    setName("");
    setAge("");
    onPersonCreated();
  };

  return (
    <form onSubmit={handleSubmit} style={{ marginBottom: "20px" }}>
      <input
        type="text"
        placeholder="Nome"
        value={name}
        onChange={(e) => setName(e.target.value)}
        style={{ marginRight: "10px" }}
      />
      <input
        type="number"
        placeholder="Idade"
        value={age}
        onChange={(e) => setAge(e.target.value)}
        style={{ marginRight: "10px" }}
      />
      <button type="submit">Adicionar Pessoa</button>
    </form>
  );
}
