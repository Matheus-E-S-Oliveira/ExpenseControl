import { useEffect, useState } from "react";
import { getDashboardSummary, type DashboardSummary } from "../services/dashboardService";

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