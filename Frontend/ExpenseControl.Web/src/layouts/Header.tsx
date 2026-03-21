import { NavLink } from "react-router-dom";

/**
 * menuItems - Itens do menu de navegação
 * Cada item possui:
 * - name: texto exibido
 * - path: rota correspondente
 */
const menuItems = [
  { name: "Dashboard", path: "/" },
  { name: "Pessoas", path: "/persons" },
  { name: "Categorias", path: "/categories" },
  { name: "Transações", path: "/transactions" },
];

/**
 * Header - Componente de cabeçalho da aplicação
 *
 * Lógica:
 * - Renderiza uma barra fixa no topo da página
 * - Mostra menu de navegação com links para cada rota
 * - Destaca a rota ativa com cor azul (#0080FF)
 * - Exibe título da aplicação ao lado direito
 *
 * Observações:
 * - Usa `NavLink` do react-router-dom para controlar estilo da rota ativa
 * - Layout em flexbox com espaçamento e sombra para destaque
 */
export default function Header() {
  return (
    <header
      style={{
        display: "flex", // flex horizontal
        justifyContent: "space-between", // separa menu e título
        alignItems: "center", // alinha verticalmente
        padding: "20px 30px", // espaçamento interno
        borderRadius: "10px", // cantos arredondados
        backgroundColor: "#fff", // fundo branco
        boxShadow: "rgba(0, 0, 0, 0.2) 0px 2px 12px", // sombra suave
      }}
    >
      {/* Menu de navegação */}
      <nav style={{ display: "flex", gap: "20px" }}>
        {menuItems.map((item) => (
          <NavLink
            key={item.path}
            to={item.path}
            style={({ isActive }) => ({
              textDecoration: "none",
              color: isActive ? "#0080FF" : "#333", // azul se ativo
              fontWeight: "bold",
              fontSize: "16px",
            })}
          >
            {item.name}
          </NavLink>
        ))}
      </nav>

      {/* Título da aplicação */}
      <h1 style={{ margin: 0, fontSize: "20px" }}>ExpenseControl</h1>
    </header>
  );
}
