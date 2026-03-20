import axios from "axios";

const API_URL = "http://localhost:5186/api/category";

export const getCategories = async () => {
  const response = await axios.get(API_URL);
  return response.data;
};

export const createCategory = async (category: { description: string; purpose: number }) => {
  const response = await axios.post(API_URL, category);
  return response.data;
};