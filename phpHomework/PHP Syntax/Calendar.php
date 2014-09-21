<?php
class Calendar
{
    private $year;
    private $headers = array('По', 'Вт', 'Ср', 'Чт', 'Пе', 'Сб', 'Не');
    private $months = array('Януари', 'Февруари', 'Март', 'Април', 'Май', 'Юни', 'Юли',
        'Август', 'Септември', 'Октомври', 'Ноември', 'Декември');


    function __construct($year)
    {
        if (!is_int($year)) {
            throw new InvalidArgumentException("Invalid year");
        }

        $this->year = $year;
    }

    function setHeaders(Array $newHeaders)
    {
        if (count($newHeaders) != 7) {
            throw new InvalidArgumentException("Invalid headers (The length must be 7)");
        }

        $this->headers = $newHeaders;
    }

    private function drawMonth($month, $year)
    {
        $date = DateTime::createFromFormat('j-n-Y', "1-${month}-${year}");

        $calendar = '<table><thead class="month-text"><th colspan="7">' . $this->months[$month - 1] . '</th></thead>';
        $calendar .= '<tr><td class="table-headers">' . implode('</td><td class="table-headers">', $this->headers) . '</td></tr>';

        $dayOfWeek = $date->format('N');
        $calendar .= '<tr class="calendar-row">';

        for ($i = 0; $i < $dayOfWeek - 1; $i++) {
            $calendar .= '<td class="empty-cells"> </td>';
        }

        $daysInMonth = $date->format('t');

        $counter = 1;
        for ($i = $dayOfWeek; $i <= $daysInMonth; $i++) {
            if ($dayOfWeek > 5) {
                $calendar .= '<td class="table-cells-weekends">';
            } else {
                $calendar .= '<td class="table-cells">';
            }
            $calendar .= '<div class="table-cell-info">' . $counter . '</div>';
            $calendar .= '</td>';

            if ($dayOfWeek == 7) {
                $calendar .= '</tr>';
                $dayOfWeek = 0;
                if ($counter != $daysInMonth) {
                    $i--;
                }

            }
            $counter++;
            if ($counter > $daysInMonth) {
                break;
            }
            $dayOfWeek++;
        }
        $calendar .= '</tr></table>';

        return $calendar;
    }

    public function draw()
    {
        echo '<div class="year-welcome-msg">' . $this->year . '</div>';
        echo '<div class="calendar">';
        for ($i = 1; $i <= 12; $i++) {
            echo $this->drawMonth($i, $this->year);
        }
        echo '</div>';
    }
}
