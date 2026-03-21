/**
 * Footer - Componente de rodapé da aplicação
 *
 * Lógica:
 * - Fica fixo na base do layout principal usando `marginTop: auto`
 * - Exibe informações de copyright e link para repositório do GitHub
 * - Usa flexbox para organizar conteúdo horizontalmente
 *
 * Observações:
 * - Link do GitHub abre em nova aba (`target="_blank"`) com segurança (`rel="noopener noreferrer"`)
 * - Ícone do GitHub usado via CDN (SVG)
 * - Estilização: fundo branco, cantos arredondados, sombra e fonte em itálico
 */
export default function Footer() {
  return (
    <footer
      style={{
        marginTop: "auto", // força o footer para a base do container
        display: "flex", // flex horizontal
        justifyContent: "space-between", // separa texto e link
        alignItems: "center", // alinhamento vertical
        padding: "20px 30px", // espaçamento interno
        borderRadius: "10px", // cantos arredondados
        backgroundColor: "#fff", // fundo branco
        boxShadow: "rgba(0, 0, 0, 0.2) 0px 2px 12px", // sombra leve
        fontStyle: "italic", // fonte em itálico
      }}
    >
      {/* Copyright */}
      <span>© developed by Matheus Eric Santos de Oliveira</span>

      {/* Link para repositório GitHub */}
      <a
        href="https://github.com/Matheus-E-S-Oliveira/ExpenseControl"
        target="_blank"
        rel="noopener noreferrer"
        style={{
          textDecoration: "none",
          color: "#0080FF",
          display: "flex",
          alignItems: "center",
          gap: "5px",
        }}
      >
        {/* Ícone GitHub */}
        <img
          src="https://cdn.jsdelivr.net/gh/simple-icons/simple-icons/icons/github.svg"
          alt="GitHub"
          width={18}
          height={18}
        />
        Matheus-E-S-Oliveira
      </a>
    </footer>
  );
}
