const amqp = require('amqplib/callback_api');
const valid = require("card-validator");

const messageBrokerInfo = {
    exchanges: {
        payment: 'payment-exhange'
    },
    queues: {
        paymentQueue: 'payment-queue'
    },
    routingKeys: {
        createOrder: 'create-order'
    }
};

const createMessageBrokerConnection = () => new Promise((resolve, reject) => {
    amqp.connect('amqp://localhost', (err, conn) => {
        if (err) { reject(err); }
        resolve(conn);
    });
});

const configureMessageBroker = channel => {
    const { exchanges, queues, routingKeys } = messageBrokerInfo;

    channel.assertExchange(exchanges.order, 'direct', { durable: true });
    channel.assertQueue(queues.paymentQueue, { durable: true });
    channel.bindQueue(queues.paymentQueue, exchanges.order, routingKeys.createOrder);
}

const createChannel = connection => new Promise((resolve, reject) => {
    connection.createChannel((err, channel) => {
        if (err) { reject(err); }
        configureMessageBroker(channel);
        resolve(channel);
    });
});

(async () => {
    const connection = await createMessageBrokerConnection();
    const channel = await createChannel(connection);

    channel.consume(paymentQueue, data => {
        var cardNumber = 0;
        var numberValidaton = valid.number(cardNumber);

        if(!numberValidaton.isPotentiallyValid)
        {
            console.log("Card number is not valid!");
        }

        else 
        {
            console.log("Card number is valid!")
        }

    }, { noAck: true });
})().catch(e => console.error(e));