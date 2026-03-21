/**
 * personService - Serviço de comunicação com a API de pessoas
 *
 * Funções disponíveis:
 *
 * getPersons:
 * - Busca todas as pessoas cadastradas
 * - Retorna um array de objetos { id, name, age }
 *
 * createPerson:
 * - Cria uma nova pessoa
 * - Recebe objeto { name, age }
 * - Retorna a resposta da API
 *
 * updatePerson:
 * - Atualiza uma pessoa existente
 * - Recebe id da pessoa e objeto { name, age }
 * - Retorna a resposta da API
 *
 * deletePerson:
 * - Exclui uma pessoa pelo id
 * - Retorna a resposta da API
 */
import axios from "axios";

const API_URL = "http://localhost:5186/api/person";

/** Busca todas as pessoas */
export const getPersons = async () => {
  const response = await axios.get(API_URL);
  return response.data;
};

/** Cria uma nova pessoa */
export const createPerson = async (person: { name: string; age: number }) => {
  const response = await axios.post(API_URL, person);
  return response.data;
};

/** Atualiza uma pessoa existente pelo id */
export const updatePerson = async (
  id: string,
  person: { name: string; age: number },
) => {
  const response = await axios.put(`${API_URL}/${id}`, person);
  return response.data;
};

/** Exclui uma pessoa pelo id */
export const deletePerson = async (id: string) => {
  const response = await axios.delete(`${API_URL}/${id}`);
  return response.data;
};