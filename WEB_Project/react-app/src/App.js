import './CSS/App.css';
import Main from "./Main/Main"
import Header from "./Header/Header"
import Footer from "./Footer/Footer"



function App() {
  return (
    
    <div className="App">
      <div>
       <Header className="App-Header"/>
       <Main className="App-Main"/>
       <Footer className="App-Footer"/>
      </div>
    </div>
  );
}

export default App;
