import React, { Component } from 'react';
import { Button, Modal, Input, Dropdown } from 'semantic-ui-react';
import axios from '../../axios';

import './AssignExerciseModal.scss';

// const subjectOptions = [
//     { key: 1, text: 'Choice 1', value: 1 },
//     { key: 2, text: 'Choice 2', value: 2 },
//     { key: 3, text: 'Choice 3', value: 3 },
// ];

class AssignExerciseModal extends Component {
    state = {
        title: '',
        subjectOptions: [],
        groupOptions: [],
        sectionOptions: [],
        exerciseOptions: [],
        variantOptions: [],
        date: null
    }

    componentDidMount = () => {
        this.loadData();
    }

    loadData = () => {
        axios.get('/api/Subjects/GetAll').then(response => {
            const sub = response.data.subjects;
            let i;

            for (i = 0; i < sub.length; i++) {
                sub[i].text = sub[i]['name'];
                sub[i].key = sub[i]['id'];
                sub[i].value = sub[i]['id'];

            }
            this.setState({subjectOptions: response.data.subjects})
        }).catch(error => {
            console.log(error.response);
        })

        axios.get('/api/Groups/GetAll').then(response => {
            const gr = response.data.groups;
            let i;

            for (i = 0; i < gr.length; i++) {
                gr[i].text = gr[i]['name'];
                gr[i].key = gr[i]['id'];
                gr[i].value = gr[i]['id'];
            }
            this.setState({groupOptions: response.data.groups})
            //console.log(this.state.groupOptions);
        }).catch(error => {
            console.log(error.response);
        })

        axios.get('/api/Sections/GetAll').then(response => {
            const sec = response.data.sections;
            let i;

            for (i = 0; i < sec.length; i++) {
                sec[i].text = sec[i]['number'];
                sec[i].key = sec[i]['id'];
                sec[i].value = sec[i]['id'];
            }
            this.setState({sectionOptions: response.data.sections})
            //console.log(this.state.sectionOptions);
        }).catch(error => {
            console.log(error.response);
        })

        axios.get('/api/Exercises/GetAll').then(response => {
            const ex = response.data.exercises;
            let i;

            for (i = 0; i < ex.length; i++) {
                ex[i].text = ex[i]['title'];
                ex[i].key = ex[i]['id'];
                ex[i].value = ex[i]['id'];
            }
            this.setState({exerciseOptions: response.data.exercises})
            //console.log(this.state.exerciseOptions);
        }).catch(error => {
            console.log(error.response);
        })

        axios.get('/api/Variants/GetAll').then(response => {
            const va = response.data.variants;
            let i;

            for (i = 0; i < va.length; i++) {
                va[i].text = va[i]['number'];
                va[i].key = va[i]['id'];
                va[i].value = va[i]['id'];
                delete va[i].content;
            }
            this.setState({variantOptions: response.data.variants})
            console.log(this.state.variantOptions);
        }).catch(error => {
            console.log(error.response);
        })


    }

    addHandle = () => {
    
    }

   

    render() {

        return (
            <Modal trigger={<Button primary>Przypisz zadanie</Button>} centered={false}>
                <Modal.Header>Przypisz zadanie</Modal.Header>
                <Modal.Content >
                    <Dropdown className='studentInput' placeholder='Przedmiot' clearable options={this.state.subjectOptions} selection />
                    <Dropdown className='studentInput' placeholder='Grupa' clearable options={this.state.groupOptions} selection />
                    <Dropdown className='studentInput' placeholder='Sekcja' clearable options={this.state.sectionOptions} selection />
                    <Dropdown className='studentInput' placeholder='Zadanie' clearable options={this.state.exerciseOptions} selection />
                    <Dropdown className='variantInput' placeholder='Wariant' clearable options={this.state.variantOptions} selection />
                    <Input className='dateInput' label='Data' placeholder='DD-MM-RRRR' onChange={this.sectionHandle} />
                </Modal.Content>
                <Modal.Actions>
                    <Button primary onClick={this.addHandle}>Zapisz</Button>
                </Modal.Actions>
            </Modal>
        )
    }

}

export default AssignExerciseModal
