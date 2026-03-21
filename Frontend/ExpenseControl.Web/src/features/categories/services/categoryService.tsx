/**
 * categoryService - Serviço para interação com API de categorias
 *
 * Funcionalidades:
 * - Buscar todas as categorias
 * - Criar nova categoria
 *
 * API:
 * - Base URL: http://localhost:5186/api/category
 */

import axios from "axios";

const API_URL = "http://localhost:5186/api/category";

/**
 * getCategories - Busca todas as categorias
 * @returns lista de categorias
 */
export const getCategories = async () => {
  const response = await axios.get(API_URL);
  return response.data;
};

/**
 * createCategory - Cria uma nova categoria
 * @param category Objeto com description e purpose
 * @returns objeto com status/mensagem da criação
 */
export const createCategory = async (category: {
  description: string;
  purpose: number;
}) => {
  const response = await axios.post(API_URL, category);
  return response.data;
};
