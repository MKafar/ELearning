import React, { Component } from 'react';
import { Button, Header, Modal, Dropdown } from 'semantic-ui-react';
import axios from '../../axios';

import './ModalAddVariant.scss';

const variantOptions = [
    { key: 1, value: 1, text: '1' },
    { key: 2, value: 2, text: '2' },
    { key: 3, value: 3, text: '3' },
    { key: 4, value: 4, text: '4' },
    { key: 5, value: 5, text: '5' },
    { key: 6, value: 6, text: '6' },
    { key: 7, value: 7, text: '7' },
    { key: 8, value: 8, text: '8' },
    { key: 9, value: 9, text: '9' },
    { key: 10, value: 10, text: '10' }
];

class ModalAddVariant extends Component {

    state = {
        number: null
    }

    handleChange = (e, { value }) => {
        this.setState({ number: value });
    }

    addHandle = () => {
        const inputVariantNumber = this.state.number;
        const selectedExercise = this.props.selectedExerciseID;
        axios.post('/api/Variants/Create', {
            number: inputVariantNumber,
            exerciseid: selectedExercise,
            content: "//Code Here"
        })
            .then(response => {
                console.log(response.data);
                this.props.updateData();
            })
            .catch(error => {
                console.log(error.response);
                alert("Nie można dodać wariantu, który już istnieje!")
            })
    }
    render() {



        return (
            <Modal closeIcon trigger={<Button primary className='modalbutton'>Dodaj wariant</Button>} centered={false}>
                <Modal.Header>Dodaj wariant</Modal.Header>
                <Modal.Content >
                    <Modal.Description >
                        <Header>Numer wariantu</Header>
                        <Dropdown 
                            className='variantInput' 
                            placeholder='Wariant' 
                            scrolling 
                            clearable 
                            options={variantOptions} 
                            onChange={this.handleChange} 
                            value={this.state.number}
                            selection 
                        />
                    </Modal.Description>
                </Modal.Content>
                <Modal.Actions>
                    <Button primary onClick={()=>{
                        this.addHandle();
                        this.props.updateData();}}>Zapisz</Button>
                </Modal.Actions>
            </Modal>
        )
    }

}

export default ModalAddVariant
