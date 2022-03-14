<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:common="http://egov.bg/RegiX/MON/HigherEdu/Common" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/MON/HigherEdu/HigherEduStudentByStatusResponse" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
	<xsl:output version="4.0" method="html" indent="no" encoding="UTF-8" doctype-public="-//W3C//DTD HTML 4.0 Transitional//EN" doctype-system="http://www.w3.org/TR/html4/loose.dtd"/>
	<xsl:param name="SV_OutputFormat" select="'HTML'"/>
	<xsl:variable name="XML" select="/"/>
	<xsl:decimal-format name="format1" grouping-separator=" " decimal-separator=","/>
	<xsl:template match="/">
		<html>
			<head>
				<title/>
			</head>
			<body>
				<xsl:for-each select="$XML">
					<xsl:for-each select="n1:HigherEduStudentByStatusResponse">
						<br/>
						<h3 align="center">
							<span>
								<xsl:text>Министерство на образованието и науката - Регистър на всички действащи и прекъснали студенти и докторанти</xsl:text>
							</span>
						</h3>
						<h2 align="center">
							<span>
								<xsl:text>Данни за студент или докторант в Регистъра на действащите и прекъснали студенти и докторанти на МОН</xsl:text>
							</span>
						</h2>
						<xsl:choose>
							<xsl:when test="count( n1:StudentData ) &gt; 0">
								<xsl:for-each select="n1:StudentData">
									<br/>
									<span>
										<xsl:text>Резултат </xsl:text>
									</span>
									<span>
										<xsl:value-of select="position()"/>
									</span>
									<span>
										<xsl:text> от </xsl:text>
									</span>
									<span>
										<xsl:value-of select="count( ../n1:StudentData)"/>
									</span>
									<br/>
									<table border="1" width="100%">
										<tbody>
											<tr>
												<td>
													<span style="font-style:italic; ">
														<xsl:text>Идентификатор на студент/докторант - ЕГН/ЛНЧ/Друг вид идентификатор</xsl:text>
													</span>
												</td>
												<td>
													<xsl:for-each select="common:StudentIdentifier">
														<span style="font-weight:bold; ">
															<xsl:apply-templates/>
														</span>
													</xsl:for-each>
												</td>
											</tr>
											<tr>
												<td>
													<span style="font-style:italic; ">
														<xsl:text>Лично име</xsl:text>
													</span>
												</td>
												<td>
													<xsl:for-each select="common:FirstName">
														<span style="font-weight:bold; ">
															<xsl:apply-templates/>
														</span>
													</xsl:for-each>
												</td>
											</tr>
											<tr>
												<td>
													<span style="font-style:italic; ">
														<xsl:text>Бащино име</xsl:text>
													</span>
												</td>
												<td>
													<xsl:for-each select="common:MiddleName">
														<span style="font-weight:bold; ">
															<xsl:apply-templates/>
														</span>
													</xsl:for-each>
												</td>
											</tr>
											<tr>
												<td height="17">
													<span style="font-style:italic; ">
														<xsl:text>Фамилия</xsl:text>
													</span>
												</td>
												<td height="17">
													<xsl:for-each select="common:LastName">
														<span style="font-weight:bold; ">
															<xsl:apply-templates/>
														</span>
													</xsl:for-each>
												</td>
											</tr>
											<tr>
												<td>
													<span style="font-style:italic; ">
														<xsl:text>Националност</xsl:text>
													</span>
												</td>
												<td>
													<xsl:for-each select="common:Nationality">
														<span style="font-weight:bold; ">
															<xsl:apply-templates/>
														</span>
													</xsl:for-each>
												</td>
											</tr>
											<tr>
												<td>
													<span style="font-style:italic; ">
														<xsl:text>Пълно наименование на висшето училище</xsl:text>
													</span>
												</td>
												<td>
													<xsl:for-each select="common:HigherSchoolName">
														<span style="font-weight:bold; ">
															<xsl:apply-templates/>
														</span>
													</xsl:for-each>
												</td>
											</tr>
											<tr>
												<td>
													<span style="font-style:italic; ">
														<xsl:text>Населено място на висшето училище</xsl:text>
													</span>
												</td>
												<td>
													<xsl:for-each select="common:HigherSchollLocation">
														<span style="font-weight:bold; ">
															<xsl:apply-templates/>
														</span>
													</xsl:for-each>
												</td>
											</tr>
											<tr>
												<td>
													<span style="font-style:italic; ">
														<xsl:text>Наименование на факултета/филияла/колежа</xsl:text>
													</span>
												</td>
												<td>
													<xsl:for-each select="common:FacultyName">
														<span style="font-weight:bold; ">
															<xsl:apply-templates/>
														</span>
													</xsl:for-each>
												</td>
											</tr>
											<tr>
												<td>
													<span style="font-style:italic; ">
														<xsl:text>Учебна година на начало на обучение</xsl:text>
													</span>
												</td>
												<td>
													<xsl:for-each select="common:EducationalYear">
														<span style="font-weight:bold; ">
															<xsl:apply-templates/>
														</span>
													</xsl:for-each>
												</td>
											</tr>
											<tr>
												<td>
													<span style="font-style:italic; ">
														<xsl:text>Семестър</xsl:text>
													</span>
												</td>
												<td>
													<xsl:for-each select="common:Semester">
														<span style="font-weight:bold; ">
															<xsl:apply-templates/>
														</span>
													</xsl:for-each>
												</td>
											</tr>
											<tr>
												<td>
													<span style="font-style:italic; ">
														<xsl:text>Квалификационна степен - ОКС (професионален бакалавър, бакалавър, магистър) или ОНС (доктор)</xsl:text>
													</span>
												</td>
												<td>
													<xsl:for-each select="common:AcquiredDegree">
														<span style="font-weight:bold; ">
															<xsl:apply-templates/>
														</span>
													</xsl:for-each>
												</td>
											</tr>
											<tr>
												<td>
													<span style="font-style:italic; ">
														<xsl:text>Професионално направление</xsl:text>
													</span>
												</td>
												<td>
													<xsl:for-each select="common:ProfessionalField">
														<span style="font-weight:bold; ">
															<xsl:apply-templates/>
														</span>
													</xsl:for-each>
												</td>
											</tr>
											<tr>
												<td height="23">
													<span style="font-style:italic; ">
														<xsl:text>Специалност</xsl:text>
													</span>
												</td>
												<td height="23">
													<xsl:for-each select="common:Subject">
														<span style="font-weight:bold; ">
															<xsl:apply-templates/>
														</span>
													</xsl:for-each>
												</td>
											</tr>
											<tr>
												<td>
													<span style="font-style:italic; ">
														<xsl:text>Курс на обучение</xsl:text>
													</span>
												</td>
												<td>
													<xsl:for-each select="common:EducationalCourse">
														<span style="font-weight:bold; ">
															<xsl:apply-templates/>
														</span>
													</xsl:for-each>
												</td>
											</tr>
											<tr>
												<td>
													<span style="font-style:italic; ">
														<xsl:text>Форма на обучение</xsl:text>
													</span>
												</td>
												<td>
													<xsl:for-each select="common:EducationalForm">
														<span style="font-weight:bold; ">
															<xsl:apply-templates/>
														</span>
													</xsl:for-each>
												</td>
											</tr>
											<tr>
												<td>
													<span style="font-style:italic; ">
														<xsl:text>Статус на студента/докторанта</xsl:text>
													</span>
												</td>
												<td>
													<xsl:for-each select="common:StudentStatus">
														<span style="font-weight:bold; ">
															<xsl:apply-templates/>
														</span>
													</xsl:for-each>
												</td>
											</tr>
											<tr>
												<td>
													<span style="font-style:italic; ">
														<xsl:text>Факултетен номер</xsl:text>
													</span>
												</td>
												<td>
													<xsl:for-each select="common:FacultyNumber">
														<span style="font-weight:bold; ">
															<xsl:apply-templates/>
														</span>
													</xsl:for-each>
												</td>
											</tr>
											<tr>
												<td>
													<span style="font-style:italic; ">
														<xsl:text>Дата на актуализация на данните в регистъра на МОН</xsl:text>
													</span>
												</td>
												<td>
													<xsl:for-each select="common:UpdateDate">
														<span style="font-weight:bold; ">
															<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00', 'format1')"/>
															<xsl:text>.</xsl:text>
															<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00', 'format1')"/>
															<xsl:text>.</xsl:text>
															<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000', 'format1')"/>
														</span>
														<span style="font-weight:bold; ">
															<xsl:text> г.</xsl:text>
														</span>
													</xsl:for-each>
												</td>
											</tr>
										</tbody>
									</table>
									<br/>
								</xsl:for-each>
								<br/>
							</xsl:when>
							<xsl:otherwise>
								<span>
									<xsl:text>Няма намерени данни в Регистъра на действащите и прекъснали студенти и докторанти на МОН за подадените критерии</xsl:text>
								</span>
							</xsl:otherwise>
						</xsl:choose>
						<br/>
					</xsl:for-each>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>