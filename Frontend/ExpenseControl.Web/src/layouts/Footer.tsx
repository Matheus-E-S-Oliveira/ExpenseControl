export default function Footer() {
  return (
    <footer
      style={{
        marginTop: "auto",
        display: "flex",
        justifyContent: "space-between",
        alignItems: "center",
        padding: '20px 30px',
        borderRadius: '10px',
        backgroundColor: '#fff',
        boxShadow: 'rgba(0, 0, 0, 0.2) 0px 2px 12px',
        fontStyle: "italic",
      }}
    >
      <span>© developed by Matheus Eric Santos de Oliveira</span>
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
