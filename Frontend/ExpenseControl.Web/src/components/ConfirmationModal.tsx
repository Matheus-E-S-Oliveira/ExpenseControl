
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
        position: "fixed",
        top: 0,
        left: 0,
        right: 0,
        bottom: 0,
        backgroundColor: "rgba(0,0,0,0.4)",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        zIndex: 999,
      }}
    >
      <div
        style={{
          backgroundColor: "#fff",
          padding: "20px",
          borderRadius: "10px",
          minWidth: "300px",
        }}
      >
        <p style={{fontSize: '18px', marginBottom: '35px'}}>{message}</p>
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
              cursor: 'pointer'
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
              cursor: 'pointer'
            }}
          >
            Confirmar
          </button>
        </div>
      </div>
    </div>
  );
}
