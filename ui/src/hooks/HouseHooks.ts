import { useQuery } from 'react-query';
import { House } from '../types/house';
import config from '../config';
import axios, { AxiosError } from 'axios';

const useFetchHouses = () => {
  return useQuery<House[], AxiosError>("houses", () => 
    axios.get(`${config.url}/houses`).then(
      (response) => response.data)
  );
}

// const useFetchHouses = (): House[] => {
//   const [houses, setHouses] = useState<House[]>([]);

//   useEffect(() => {
//     const f = async () => {
//       const api = await fetch(`${config.url}/houses`);
//       const houses = await api.json();
//       setHouses(houses);
//     };
//     f();
//   }, []);

//   return houses;
// }

const useFetchHouse = (id: number) => {
  return useQuery<House, AxiosError>(["houses", id], () => 
    axios.get(`${config.url}/house/${id}`).then(
      (response) => response.data)
  );
}

export default useFetchHouses;
export { useFetchHouse };