import axios from "axios";

const API_URL = 'http://localhost:5186/api/person';

export const getPersons = async () => {
  const response = await axios.get(API_URL);
  return response.data;
};

export const createPerson = async (person: { name: string; age: number }) => {
  const response = await axios.post(API_URL, person);
  return response.data;
};

export const updatePerson = async (id: string, person: { name: string; age: number }) => {
  const response = await axios.put(`${API_URL}/${id}`, person);
  return response.data;
};

export const deletePerson = async (id: string) => {
    const response = await axios.delete(`${API_URL}/${id}`);
    return response.data
}