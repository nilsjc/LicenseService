import logo from './logo.svg';
import './App.css';
import FetchLicense from './fetchlicense.js'
import EnterAdminMode from './admin.js'
import PushLicense from './pushlicense.js'
function App() {
  return (
    <div className="App">
          <header className="App-header">
              <FetchLicense name="Adam" />
              <FetchLicense name="Bertil" />
              <FetchLicense name="David" />
        <p>
          License Generator
        </p>
              <a>
                  <PushLicense />
              </a>
              <EnterAdminMode />
      </header>
    </div>
  );
}

export default App;
