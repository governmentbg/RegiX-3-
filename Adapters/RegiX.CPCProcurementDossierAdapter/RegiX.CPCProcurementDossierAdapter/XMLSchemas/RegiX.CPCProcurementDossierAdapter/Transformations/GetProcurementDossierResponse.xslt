<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
	<xsl:output version="4.0" method="html" indent="no" encoding="UTF-8" doctype-public="-//W3C//DTD HTML 4.0 Transitional//EN" doctype-system="http://www.w3.org/TR/html4/loose.dtd"/>
	<xsl:param name="SV_OutputFormat" select="'HTML'"/>
	<xsl:variable name="XML" select="/"/>
	<xsl:template match="/">
		<html>
			<head>
				<title/>
			</head>
			<body>
				<xsl:for-each select="$XML">
					<br/>
					<h3 align="center">
						<span>
							<xsl:text>Комисия за защита на конкуренцията</xsl:text>
						</span>
					</h3>
					<br/>
					<h2 align="center">
						<span>
							<xsl:text>Справка за жалби по ЗОП</xsl:text>
						</span>
					</h2>
					<xsl:for-each select="GetProcurementDossierResponse">
						<br/>
						<xsl:for-each select="ResultMessage">
							<span style="font-weight:bold; ">
								<xsl:text>Информационно съобщение:</xsl:text>
							</span>
							<span>
								<xsl:text>&#160;</xsl:text>
							</span>
							<xsl:apply-templates/>
						</xsl:for-each>
						<br/>
						<xsl:for-each select="ResultStatus">
							<span style="font-weight:bold; ">
								<xsl:text>Статус на резултата:</xsl:text>
							</span>
							<span>
								<xsl:text>&#160;</xsl:text>
							</span>
							<xsl:apply-templates/>
						</xsl:for-each>
						<br/>
						<br/>
						<xsl:for-each select="ProcurementDossiers">
							<xsl:for-each select="ProcurementDossier">
								<br/>
								<span>
									<xsl:value-of select="position()"/>
								</span>
								<span>
									<xsl:text> от </xsl:text>
								</span>
								<span>
									<xsl:value-of select="count( /GetProcurementDossierResponse/ProcurementDossiers/ProcurementDossier )"/>
								</span>
								<br/>
								<hr/>
								<br/>
								<xsl:for-each select="ProcurementNumber">
									<span style="font-weight:bold; ">
										<xsl:text>Уникален номер на поръчка в РОП: </xsl:text>
									</span>
									<xsl:apply-templates/>
								</xsl:for-each>
								<br/>
								<xsl:for-each select="ProceedingsNumber">
									<span style="font-weight:bold; ">
										<xsl:text>Номер на производство:</xsl:text>
									</span>
									<span>
										<xsl:text>&#160;</xsl:text>
									</span>
									<xsl:apply-templates/>
								</xsl:for-each>
								<br/>
								<xsl:for-each select="ProceedingsStartDate">
									<span style="font-weight:bold; ">
										<xsl:text>Дата на образуване:</xsl:text>
									</span>
									<span>
										<xsl:text>&#160;</xsl:text>
									</span>
									<span>
										<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
										<xsl:text>.</xsl:text>
										<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
										<xsl:text>.</xsl:text>
										<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
									</span>
									<span>
										<xsl:text> г.</xsl:text>
									</span>
								</xsl:for-each>
								<br/>
								<xsl:for-each select="ProceedingsCloseDate">
									<span style="font-weight:bold; ">
										<xsl:text>Дата на приключване:</xsl:text>
									</span>
									<span>
										<xsl:text>&#160;</xsl:text>
									</span>
									<span>
										<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
										<xsl:text>.</xsl:text>
										<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
										<xsl:text>.</xsl:text>
										<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
									</span>
									<span>
										<xsl:text> г.</xsl:text>
									</span>
								</xsl:for-each>
								<br/>
								<xsl:for-each select="LegalBase">
									<span style="font-weight:bold; ">
										<xsl:text>Правно основание: </xsl:text>
									</span>
									<xsl:apply-templates/>
								</xsl:for-each>
								<br/>
								<xsl:for-each select="ProceedingsType">
									<span style="font-weight:bold; ">
										<xsl:text>Вид производство:</xsl:text>
									</span>
									<span>
										<xsl:text>&#160;</xsl:text>
									</span>
									<xsl:apply-templates/>
								</xsl:for-each>
								<br/>
								<xsl:for-each select="DossierLink">
									<span style="font-weight:bold; ">
										<xsl:text>Връзка към портала на КЗК:</xsl:text>
									</span>
									<span>
										<xsl:text>&#160;</xsl:text>
									</span>
									<xsl:apply-templates/>
								</xsl:for-each>
								<br/>
								<xsl:for-each select="RegisterID">
									<span style="font-weight:bold; ">
										<xsl:text>Входящ номер на жалба:</xsl:text>
									</span>
									<span>
										<xsl:text>&#160;</xsl:text>
									</span>
									<xsl:apply-templates/>
								</xsl:for-each>
								<br/>
								<xsl:for-each select="ProceedingsSubsections">
									<span style="font-weight:bold; ">
										<xsl:text>Предмети и подпредмети:</xsl:text>
									</span>
									<br/>
									<ul>
										<xsl:for-each select="ProceedingSubsection">
											<li>
												<xsl:apply-templates/>
											</li>
										</xsl:for-each>
									</ul>
									<br/>
								</xsl:for-each>
								<br/>
								<xsl:for-each select="Initiators">
									<span style="font-weight:bold; ">
										<xsl:text>Инициатор(и):</xsl:text>
									</span>
									<br/>
									<ul>
										<xsl:for-each select="Initiator">
											<li>
												<xsl:apply-templates/>
											</li>
										</xsl:for-each>
									</ul>
									<br/>
								</xsl:for-each>
								<br/>
								<xsl:for-each select="Defendants">
									<span style="font-weight:bold; ">
										<xsl:text>Ответник(ници):</xsl:text>
									</span>
									<br/>
									<ul>
										<xsl:for-each select="Defendant">
											<li>
												<xsl:apply-templates/>
											</li>
										</xsl:for-each>
									</ul>
									<br/>
								</xsl:for-each>
								<br/>
								<xsl:for-each select="UnitedProceedings">
									<span style="font-weight:bold; ">
										<xsl:text>Обединена с производство:</xsl:text>
									</span>
									<br/>
									<ul>
										<xsl:for-each select="UnitedProceeding">
											<li>
												<xsl:apply-templates/>
											</li>
										</xsl:for-each>
									</ul>
								</xsl:for-each>
								<br/>
								<br/>
								<xsl:for-each select="InterimMeasures">
									<span style="font-weight:bold; ">
										<xsl:text>Искане за временни мерки:</xsl:text>
									</span>
									<span>
										<xsl:text>&#160;</xsl:text>
									</span>
									<xsl:choose>
										<xsl:when test=". = true">
											<span>
												<xsl:text>Да</xsl:text>
											</span>
										</xsl:when>
										<xsl:otherwise>
											<span>
												<xsl:text>Не.</xsl:text>
											</span>
										</xsl:otherwise>
									</xsl:choose>
								</xsl:for-each>
								<br/>
								<xsl:for-each select="ImposedInterimMeasures">
									<span style="font-weight:bold; ">
										<xsl:text>Има ли наложени временни мерки</xsl:text>
									</span>
									<span>
										<xsl:text>:</xsl:text>
									</span>
									<br/>
									<ul>
										<xsl:for-each select="ImposedInterimMeasure">
											<li>
												<xsl:apply-templates/>
											</li>
										</xsl:for-each>
									</ul>
								</xsl:for-each>
								<br/>
								<xsl:for-each select="CurrentStatus">
									<span style="font-weight:bold; ">
										<xsl:text>Текущ статус:</xsl:text>
									</span>
									<span>
										<xsl:text>&#160;</xsl:text>
									</span>
									<xsl:apply-templates/>
								</xsl:for-each>
								<br/>
								<xsl:for-each select="DossierPublishDate">
									<span style="font-weight:bold; ">
										<xsl:text>Дата на публикуване:</xsl:text>
									</span>
									<span>
										<xsl:text>&#160;</xsl:text>
									</span>
									<span>
										<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
										<xsl:text>.</xsl:text>
										<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
										<xsl:text>.</xsl:text>
										<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
									</span>
									<span>
										<xsl:text> г.</xsl:text>
									</span>
								</xsl:for-each>
								<br/>
								<xsl:for-each select="LastDecisionPublishDate">
									<span style="font-weight:bold; ">
										<xsl:text>Дата на публикуване на последното решение:</xsl:text>
									</span>
									<span>
										<xsl:text>&#160;</xsl:text>
									</span>
									<span>
										<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
										<xsl:text>.</xsl:text>
										<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
										<xsl:text>.</xsl:text>
										<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
									</span>
									<span>
										<xsl:text> г.</xsl:text>
									</span>
								</xsl:for-each>
								<br/>
								<xsl:for-each select="ImposedPenalties">
									<span style="font-weight:bold; ">
										<xsl:text>Наложени санкции:</xsl:text>
									</span>
									<br/>
									<ul>
										<xsl:for-each select="ImposedPenalty">
											<li>
												<xsl:apply-templates/>
											</li>
										</xsl:for-each>
									</ul>
								</xsl:for-each>
							</xsl:for-each>
						</xsl:for-each>
						<br/>
					</xsl:for-each>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>