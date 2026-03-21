/**
 * Category - Tipo de dados para uma categoria
 *
 * Propriedades:
 * - id: identificador único da categoria
 * - description: descrição da categoria
 * - purpose: finalidade da categoria (1 = Despesa, 2 = Receita, 3 = Ambos)
 */
export type Category = {
  id: string;
  description: string;
  purpose: number;
};