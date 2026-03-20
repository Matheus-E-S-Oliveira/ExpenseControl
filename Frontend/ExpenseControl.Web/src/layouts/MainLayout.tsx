import React from "react";
import Header from "./Header";
import Footer from "./Footer";

type Props = {
  children: React.ReactNode;
};

export default function MainLayout({ children }: Props) {
  return (
    <div
      style={{
        height: "100vh",
        padding: "20px",
        display: "flex",
        flexDirection: "column",
        overflow: "auto",
        boxSizing: 'border-box',
        fontFamily: "'Segoe UI', Tahoma, Geneva, Verdana, sans-serif",
      }}
    >
      <Header />
      <main
        style={{
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
          
        }}
      >
        {children}
      </main>
      <Footer />
    </div>
  );
}
