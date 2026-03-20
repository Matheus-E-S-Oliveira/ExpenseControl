import axios from "axios";

const API_URL = "http://localhost:5186/api/transaction";

export const getTransactions = async () => {
  const response = await axios.get(API_URL);
  return response.data;
};

export const createTransaction = async (data: {
  description: string;
  value: number;
  type: number;
  personId: string;
  categoryId: string;
}) => {
  const response = await axios.post(API_URL, data);
  return response.data;
};