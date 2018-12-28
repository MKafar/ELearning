import React from 'react'
import { Container, List, Button } from 'semantic-ui-react'

import './DetailList.scss'


const DetailList = (props) => {

    const detailsHandler = () => {
        console.log('Szczegóły', props.number);
    }

    return (
        <div>
            <Container>
                <List divided relaxed>
                    <List.Item>
                        <List.Content floated='right'>
                            <Button onClick={detailsHandler}> Szczegóły </Button>
                        </List.Content>
                        <List.Content floated='left'>
                            { props.number }
                        </List.Content>
                        <List.Content  floated='left'>
                            { props.date }
                        </List.Content>
                        <List.Content >
                            { props.title }
                        </List.Content>
                    </List.Item>
                </List>
            </Container>

        </div>

    );
}

export default DetailList;