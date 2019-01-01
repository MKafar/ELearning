import React, { Component } from 'react';

import './AdminExercises.scss';
import SearchExercise from '../../components/Modules/SearchExercise';
import DetailList from '../../components/Modules/DeatilList';
import axios from '../../axios';
import { Button, Icon } from 'semantic-ui-react';
import ModalAdd from '../../components/Modules/ModalAdd';

class AdminExercises extends Component {

    state = {
        exercises: [],
        value: '',
        selectedItem: [],
        showSelected: false
    }

    componentDidMount() {
        axios.get('/api/Exercises/GetAll')
            .then(response => {
                this.setState({ exercises: response.data.exercises })
            });
    }


    valueHandle = (selectedValue) => {
        this.setState({ value: selectedValue });
        this.viewData(selectedValue);
        this.setState({showSelected: true});
    }

    viewData = (selectedId) => {
        //const selectedExercise = this.state.exercises.slice();
        axios.get('/api/Exercises/GetById/' + selectedId)
            .then(response => {
                this.setState({ selectedItem: response.data });
            });
    }

    reverseState = () => {
        this.setState({ showSelected: false });
    }

    addnewHandler = () => {
        
    }
  
    render() {


        return (
            <div className='adminExercises'>
                <div className='searching'>
                    <div className='content'>
                        <SearchExercise
                            onSelectValue={this.valueHandle} />
                    </div>
                    <Button icon onClick={this.reverseState}><Icon name='delete' /></Button>
                    {/* <Button onClick={this.addnewHandler}>Dodaj zadanie</Button> */}
                    <ModalAdd addHanlde={this.addnewHandler}/>
                </div>

                <div className='exerciseList'>
                    {this.state.showSelected ?
                        <div>
                            <DetailList
                                key={this.state.selectedItem.id}
                                id={this.state.selectedItem.id}
                                title={this.state.selectedItem.title} />
                        </div>
                        :
                        this.state.exercises.map((exercise) => {
                            return <DetailList
                                key={exercise.id}
                                id={exercise.id}
                                title={exercise.title} />
                        })
                    }
                </div>
            </div>
        );
    }
}

export default AdminExercises;