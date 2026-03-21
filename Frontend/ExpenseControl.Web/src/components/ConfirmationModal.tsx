/**
 * ConfirmationModal - Modal de confirmação de ações
 *
 * Props:
 * - message: mensagem exibida no modal
 * - onConfirm: função chamada ao confirmar
 * - onCancel: função chamada ao cancelar
 *
 * Lógica:
 * - Overlay fixa cobrindo toda a tela (posição fixa + background semi-transparente)
 * - Caixa centralizada com a mensagem e botões de ação
 * - Botões "Cancelar" e "Confirmar" com cores e interação visual
 *
 * Observações:
 * - Pode ser reutilizado em qualquer parte da aplicação que precise confirmar uma ação do usuário
 * - zIndex alto para garantir que fique acima de outros elementos
 * - Flexbox usado para centralizar o conteúdo vertical e horizontalmente
 */
type Props = {
  message: string;
  onConfirm: () => void;
  onCancel: () => void;
};

export default function ConfirmationModal({
  message,
  onConfirm,
  onCancel,
}: Props) {
  return (
    <div
      style={{
        position: "fixed", // overlay fixo na tela
        top: 0,
        left: 0,
        right: 0,
        bottom: 0,
        backgroundColor: "rgba(0,0,0,0.4)", // fundo semi-transparente
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
        }}
      >
        {/* Mensagem */}
        <p style={{ fontSize: "18px", marginBottom: "35px" }}>{message}</p>

        {/* Botões */}
        <div
          style={{ display: "flex", justifyContent: "flex-end", gap: "10px" }}
        >
          <button
            onClick={onCancel}
            style={{
              backgroundColor: "#aaa",
              color: "#fff",
              border: "none",
              padding: "10px",
              borderRadius: "5px",
              cursor: "pointer",
            }}
          >
            Cancelar
          </button>
          <button
            onClick={onConfirm}
            style={{
              backgroundColor: "#FF3D00",
              color: "#fff",
              border: "none",
              padding: "10px",
              borderRadius: "5px",
              cursor: "pointer",
            }}
          >
            Confirmar
          </button>
        </div>
      </div>
    </div>
  );
}