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
    <div style={{ padding: 20 }}>
      <img src="/images/sheaf-of-rice.jpg" /><h1>Cereal API - Now Online</h1>
      <ul>
        {cereals.map(c => (
          <li key={c.id}> {c.name} - {c.rating}</li>
        ))}
      </ul>
    </div>
  )
}

export default App