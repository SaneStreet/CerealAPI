import React, { useState, useEffect} from "react";

type Cereal = {
  id: number,
  name: string,
  rating: number
}

const App: React.FC = () => {
  const [cereals, setCereals] = useState<Cereal[]>([])

  useEffect(() => {
    fetch('/api/Cereal')
      .then(res => res.json())
      .then(setCereals)
      .then(err => console.error(err))
  }, [])

  return (
    <div style={{ padding: 20, fontFamily: 'Arial, sans-serif' }}>
      <img 
        src="/images/sheaf-of-rice.jpg" 
        alt="Sheaf of Rice" 
        style={{ maxWidth: 200, display: 'block', marginBottom: 20 }} 
      />
      <h1 style={{ marginBottom: 20 }}>Cereal API - A Cereal Company</h1>

      <table style={{ 
        borderCollapse: 'collapse', 
        width: '100%', 
        textAlign: 'left', 
        boxShadow: '0 0 10px rgba(0,0,0,0.1)' 
      }}>
        <thead style={{ backgroundColor: '#f0f0f0', color: '#000' }}>
          <tr>
            <th style={{ padding: '12px', borderBottom: '2px solid #ccc' }}>Name</th>
            <th style={{ padding: '12px', borderBottom: '2px solid #ccc' }}>Rating</th>
          </tr>
        </thead>
        <tbody>
          {cereals.map(c => (
            <tr 
              key={c.id} 
              style={{ 
                borderBottom: '1px solid #eee', 
                transition: 'background-color 0.5s' 
              }}
              onMouseEnter={e => (e.currentTarget.style.backgroundColor = '#fafafa', e.currentTarget.style.color = '#000')}
              onMouseLeave={e => (e.currentTarget.style.backgroundColor = 'transparent', e.currentTarget.style.color = '#fff')}
            >
              <td style={{ padding: '10px' }}>{c.name}</td>
              <td style={{ padding: '10px' }}>{c.rating}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  )
}

export default App