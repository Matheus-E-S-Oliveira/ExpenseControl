type Props = {
  message: string;
  onClose: () => void;
  success?: boolean;
};

export default function ModalGlobal({ message, onClose, success = true }: Props) {
  return (
    <div
      style={{
        position: "fixed",
        top: 0,
        left: 0,
        right: 0,
        bottom: 0,
        backgroundColor: "rgba(0,0,0,0.3)",
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
          textAlign: "center",
          boxShadow: "rgba(0,0,0,0.2) 0px 2px 10px",
        }}
      >
        <p style={{ color: success ? "#0080FF" : "#FF3D00", fontWeight: "bold" }}>
          {message}
        </p>
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