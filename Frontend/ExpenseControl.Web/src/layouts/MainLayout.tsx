import React from "react";
import Header from "./Header";
import Footer from "./Footer";

/**
 * MainLayout - Layout principal da aplicação
 *
 * Lógica:
 * - Recebe `children` como conteúdo dinâmico que será exibido entre Header e Footer
 * - Define estrutura de página com Header no topo, Footer no final e área principal centralizada
 * - Estilização inline para garantir altura total da tela e espaçamento consistente
 *
 * Observações:
 * - `flexDirection: "column"` organiza Header, main e Footer em coluna
 * - `overflow: "auto"` permite rolagem se o conteúdo for maior que a tela
 * - Fonte padrão definida para consistência visual
 */
type Props = {
  children: React.ReactNode;
};

export default function MainLayout({ children }: Props) {
  return (
    <div
      style={{
        height: "100vh", // altura total da viewport
        padding: "20px", // espaçamento interno
        display: "flex", // usa flexbox
        flexDirection: "column", // Header, main e Footer em coluna
        overflow: "auto", // permite rolagem vertical
        boxSizing: "border-box", // padding incluso na largura/altura
        fontFamily: "'Segoe UI', Tahoma, Geneva, Verdana, sans-serif", // fonte padrão
      }}
    >
      {/* Header fixo no topo */}
      <Header />

      {/* Área principal centralizada */}
      <main
        style={{
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
        }}
      >
        {children} {/* Conteúdo dinâmico das páginas */}
      </main>

      {/* Footer fixo na base */}
      <Footer />
    </div>
  );
}
