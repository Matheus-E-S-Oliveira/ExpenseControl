export type Transaction = {
  id: string;
  description: string;
  value: number;
  type: number; 
  person?: {
    id: string;
    name: string;
  };
  category?: {
    id: string;
    description: string;
    purpose: number;
  };
};