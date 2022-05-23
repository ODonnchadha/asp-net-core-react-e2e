import { useEffect, useState } from 'react';
import { House } from '../types/house';
import config from '../config';

const useFetchHouses = (): House[] => {
  const [houses, setHouses] = useState<House[]>([]);

  useEffect(() => {
    const f = async () => {
      const api = await fetch(`${config.url}/houses`);
      const houses = await api.json();
      setHouses(houses);
    };
    f();
  }, []);

  return houses;
}

export default useFetchHouses;