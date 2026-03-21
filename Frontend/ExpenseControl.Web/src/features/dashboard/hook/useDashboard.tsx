import { useEffect, useState } from "react";
import {
  getDashboardSummary,
  type DashboardSummary,
} from "../services/dashboardService";

/**
 * useDashboard - hook customizado para consumir dados do dashboard
 *
 * Lógica:
 * - Inicializa estados:
 *   - data: armazena o resumo do dashboard ou null
 *   - loading: indica carregamento em andamento
 *   - error: armazena mensagem de erro caso falhe a requisição
 * - useEffect é executado uma vez ao montar o componente:
 *   - chama getDashboardSummary() para buscar os dados
 *   - trata sucesso: salva os dados em `data`
 *   - trata erro: salva a mensagem em `error`
 *   - sempre atualiza `loading` ao final
 *
 * Retorno:
 * - { data, loading, error }
 *   - data: DashboardSummary | null
 *   - loading: boolean
 *   - error: string | null
 */
export default function useDashboard() {
  const [data, setData] = useState<DashboardSummary | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        setLoading(true);
        const summary = await getDashboardSummary();
        setData(summary);
      } catch (err: any) {
        setError(err.message || "Erro ao carregar o dashboard");
      } finally {
        setLoading(false);
      }
    };

    fetchData();
  }, []);

  return { data, loading, error };
}