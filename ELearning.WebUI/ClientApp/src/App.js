import React, { Component } from 'react';
import 'semantic-ui-css/semantic.min.css';
import 'semantic-ui-react';
import {BrowserRouter} from 'react-router-dom';

import './App.css';
import Student from './containers/Student/Student';
import Admin from './containers/Admin/Admin';

class App extends Component {


  state = {
    exercises: [
      { number: 1, title: 'Jakiś tytuł ćwiczenia' },
      { number: 2, title: 'B' },
      { number: 3, title: 'C' },
      { number: 4, title: 'D' },
      { number: 5, title: 'E' },
      { number: 6, date: '01.01.18', title: 'Kolejny długaśny bardzo długi tytuł, no bardzo długi ffffffffffffffffff ffffffffffffffffffffffff' }
    ],
    searches: [
      { date: '01.02.18', lab: 'PP', exercise: 'A', student: 'Mateusz M'},
      { date: '02.02.18', lab: 'PP', exercise: 'B', student: 'Mateusz A'},
      { date: '03.02.18', lab: 'PP', exercise: 'A', student: 'Mateusz K'}
    ]
  }



  render() {


    return (
      <BrowserRouter>
        <div className='App'>
          {/* <Student /> */}
          <Admin />
        </div>
      </BrowserRouter>










        /* 
        //różne mody jednego komponentu
            <CodeWindow code={code}></CodeWindow>
            <CodeWindow changeMode={true} code={'Hello'}></CodeWindow>
        // tabela szukania
           { this.state.searches.map((search) => {
           return <SearchTable
           date = { search.date }
           lab = { search.lab }
           exercise = { search.exercise }
           student = { search.student } />
           })}
        
        
        //lista zadań
        <div className = 'detailList'>
            {this.state.exercises.map((exercise) => {
              return <DetailList
                number = { exercise.number }
                title = { exercise.title }
                date = { exercise.date }/>
            } )}
          </div> */


        /*
      <div className = "menu">
      <Menu></Menu>
      </div>
        <div className="logincontainer">
          <LoginInput></LoginInput>
          <LoginButton></LoginButton>
        </div>
        

         <div className='coding'>
          <Codemirror></Codemirror>
          <Output></Output>
        </div>
        */

      
    );
  }
}

export default App;