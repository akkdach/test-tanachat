import logo from './logo.svg';
import './App.css';
import {QueryClient,QueryClientProvider,useQuery} from 'react-query'
import ProductPage from './Pages/ProductPage'
function App() {
  return (
      <QueryClientProvider client={QueryClient} >
        <ProductPage />
      </QueryClientProvider>

  );
}

export default App;
