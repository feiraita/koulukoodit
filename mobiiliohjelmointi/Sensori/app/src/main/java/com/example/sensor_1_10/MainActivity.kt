package com.example.sensor_1_10

import android.hardware.Sensor
import android.hardware.SensorEvent
import android.hardware.SensorEventListener
import android.hardware.SensorManager
import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.activity.enableEdgeToEdge
import androidx.compose.foundation.Canvas
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.padding
import androidx.compose.material3.Scaffold
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.runtime.mutableStateOf
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.tooling.preview.Preview
import com.example.sensor_1_10.ui.theme.Sensor_1_10Theme

class MainActivity : ComponentActivity(), SensorEventListener {
    private lateinit var sensorManager: SensorManager
    private var accelerometer: Sensor? = null

    //tehdään lista
    val sensoriArvoLista = mutableListOf<Pair<Float, Float>>()
    val xArvo = mutableStateOf("")
    val yArvo = mutableStateOf("")
    val zArvo = mutableStateOf("")

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContent {
            Sensor_1_10Theme {
                Scaffold(modifier = Modifier.fillMaxSize()) { innerPadding ->
                    Column(modifier = Modifier.padding(innerPadding))
                    {
                        Text(text = xArvo.value)
                        Text(text = yArvo.value)
                        Text(text = zArvo.value)

                    }
                    SensorLineDrawing(sensoriArvoLista, Modifier.fillMaxSize())
                }
            }
        }
        sensorManager = getSystemService(SENSOR_SERVICE) as SensorManager
        accelerometer = sensorManager.getDefaultSensor(Sensor.TYPE_ACCELEROMETER)
    }

    override fun onResume() {
        super.onResume()
        accelerometer?.also { acc ->
            sensorManager.registerListener(this, acc, SensorManager.SENSOR_DELAY_NORMAL)
        }
    }

    override fun onPause() {
        super.onPause()
        sensorManager.unregisterListener(this)
    }

    override fun onSensorChanged(event: SensorEvent) {
        if (event.sensor?.type == Sensor.TYPE_ACCELEROMETER) {
            val x = event.values[0]
            val y = event.values[1]
            val z = event.values[2]

            //lisätään nykyinen x- ja y-arvo listaan
            sensoriArvoLista.add(Pair(x, y))

            //update sensoriarvot
            xArvo.value = "X: $x"
            yArvo.value = "Y: $y"
            zArvo.value = "Z: $z"
        }
    }

    override fun onAccuracyChanged(sensor: Sensor?, accuracy: Int) {}

    @Composable
    fun SensorLineDrawing(sensoriArvoLista: List<Pair<Float, Float>>, modifier: Modifier) {
        Canvas(modifier = modifier) {
            if (sensoriArvoLista.isNotEmpty()) {
                val path = androidx.compose.ui.graphics.Path().apply {
                    moveTo(
                        ((sensoriArvoLista[0].first.coerceIn(-10f, 10f) + 10) * (size.width / 20)),
                        ((sensoriArvoLista[0].second.coerceIn(-10f, 10f)+ 10) * (size.height / 20))
                    )

                    for (sensoriArvo in sensoriArvoLista.drop(1)) {
                        lineTo(
                            ((sensoriArvo.first.coerceIn(-10f, 10f) + 10) * (size.width / 20)),
                            ((sensoriArvo.second.coerceIn(-10f, 10f) + 10) * (size.height / 20))
                        )
                    }
                }

                drawPath(
                    path = path,
                    color = Color.Black,
                    style = androidx.compose.ui.graphics.drawscope.Stroke(width = 5f)
                )

                // piirtoviivan pääpiste
                val piste = sensoriArvoLista.last()

                // Calculate scaled x and y coordinates for the last point
                val xPiste = (piste.first.coerceIn(-10f, 10f) + 10) * (size.width / 20)
                val yPiste = (piste.second.coerceIn(-10f, 10f) + 10) * (size.height / 20)

                drawCircle(
                    color = Color.Red,
                    radius = 10f,
                    center = androidx.compose.ui.geometry.Offset(xPiste, yPiste)
                )
            }
        }
    }

    @Preview(showBackground = true)
    @Composable
    fun GreetingPreview() {
        Sensor_1_10Theme {}
    }
}