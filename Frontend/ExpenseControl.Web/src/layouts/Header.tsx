import { NavLink } from 'react-router-dom';

const menuItems = [
  { name: 'Dashboard', path: '/' },
  { name: 'Pessoas', path: '/persons' },
  { name: 'Categorias', path: '/categories' },
  { name: 'Transações', path: '/transactions' },
];

export default function Header() {
  return (
    <header
      style={{
        display: 'flex',
        justifyContent: 'space-between',
        alignItems: 'center',
        padding: '20px 30px',
        borderRadius: '10px',
        backgroundColor: '#fff',
        boxShadow: 'rgba(0, 0, 0, 0.2) 0px 2px 12px',
      }}
    >
      <nav style={{ display: 'flex', gap: '20px' }}>
        {menuItems.map(item => (
          <NavLink
            key={item.path}
            to={item.path}
            style={({ isActive }) => ({
              textDecoration: 'none',
              color: isActive ? '#0080FF' : '#333',
              fontWeight: 'bold',
              fontSize: '16px',
            })}
          >
            {item.name}
          </NavLink>
        ))}
      </nav>
      <h1 style={{ margin: 0, fontSize: '20px' }}>ExpenseControl</h1>
    </header>
  );
}