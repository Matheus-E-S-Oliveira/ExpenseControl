import React from 'react';

type Props = {
  title?: string;
  children: React.ReactNode;
  style?: React.CSSProperties;
};

export default function Card({ title, children, style }: Props) {
  return (
    <div
      style={{
        backgroundColor: '#ffffff',
        boxShadow: '0 4px 8px rgba(0,0,0,0.1)',
        borderRadius: '10px',
        padding: '20px',
        width: '100%',
        maxWidth: '800px',
        ...style,
      }}
    >
      {title && <h2 style={{ marginTop: 0 }}>{title}</h2>}
      {children}
    </div>
  );
}