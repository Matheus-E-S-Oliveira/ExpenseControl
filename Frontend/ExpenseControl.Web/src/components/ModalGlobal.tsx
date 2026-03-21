/**
 * ModalGlobal - Modal genérico para exibir mensagens de sucesso ou erro
 *
 * Props:
 * - message: mensagem exibida no modal
 * - onClose: função chamada ao fechar o modal
 * - success (opcional): indica se a mensagem é de sucesso (true) ou erro (false). Default: true
 *
 * Lógica:
 * - Overlay fixo cobrindo toda a tela (posição fixa + background semi-transparente)
 * - Caixa centralizada com mensagem e botão de fechar
 * - Cor do texto e do botão muda de acordo com `success`
 *
 * Observações:
 * - Reutilizável para qualquer feedback visual ao usuário
 * - zIndex alto garante que fique acima de outros elementos
 * - Flexbox centraliza conteúdo vertical e horizontalmente
 */
type Props = {
  message: string;
  onClose: () => void;
  success?: boolean;
};

export default function ModalGlobal({
  message,
  onClose,
  success = true,
}: Props) {
  return (
    <div
      style={{
        position: "fixed", // overlay fixo
        top: 0,
        left: 0,
        right: 0,
        bottom: 0,
        backgroundColor: "rgba(0,0,0,0.3)", // fundo semi-transparente
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        zIndex: 999, // acima de outros elementos
      }}
    >
      {/* Caixa do modal */}
      <div
        style={{
          backgroundColor: "#fff",
          padding: "20px",
          borderRadius: "10px",
          minWidth: "300px",
          textAlign: "center",
          boxShadow: "rgba(0,0,0,0.2) 0px 2px 10px",
        }}
      >
        {/* Mensagem */}
        <p
          style={{ color: success ? "#0080FF" : "#FF3D00", fontWeight: "bold" }}
        >
          {message}
        </p>

        {/* Botão de fechar */}
        <button
          onClick={onClose}
          style={{
            marginTop: "15px",
            padding: "8px 12px",
            borderRadius: "5px",
            border: "none",
            backgroundColor: success ? "#0080FF" : "#FF3D00",
            color: "#fff",
            cursor: "pointer",
          }}
        >
          Fechar
        </button>
      </div>
    </div>
  );
}
